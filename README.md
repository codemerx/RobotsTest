# RobotsTest

The project exposes all the functionality via simple  REST API. Each run is persisted in a database and the results can be requested at a later point.

- Setup
    - Development mode / Visual Studio
        - VS 2022 is needed because the project is on dotnet 6.
        - Run the command "update-database" in the package manager console in order to apply the migrations.
        - Run the RobotsApi project.
    - Production mode / Docker
        - In the project root execute 
        
        ```
        docker build -f ./DockerFile . -t robots/mars:1.0

        docker run —env CONNECTIONSTRINGS__ROBOTSDATABSE=<db connection string> --rm robots/mars:1.0 dotnet ef database update

        docker run —env CONNECTIONSTRINGS__ROBOTSDATABSE=<db connection string> robots/mars:1.0 dotnet RobotsApi.dll
        ```

        Database connection string needs to be provided in the value of CONNECTIONSTRINGS__ROBOTSDATABSE. This database is going to be used to persist the results of each run.

- API Reference
    - [POST] https://localhost:8111/Grids - Allows sending the input data and returns the final positions of all robots.
        - Sample input: 
                
        ```
        {
            "input": "5 3\r\n1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL"
        }
        ```
  
        - Please note the \r\n usage
        - Sample Response
        
        ```
        {
            "id": 1,
            "xSize": 5,
            "ySize": 3,
            "robots": [
                {
                    "isLost": false,
                    "xPosition": 1,
                    "yPosition": 1,
                    "orientation": "E"
                },
                {
                    "isLost": true,
                    "xPosition": 3,
                    "yPosition": 3,
                    "orientation": "N"
                },
                {
                    "isLost": false,
                    "xPosition": 4,
                    "yPosition": 2,
                    "orientation": "N"
                }
            ]
        }
        ```
        
        Each run result is persisted under unique id on the server side. The id is returned in the id property and can be used to retrieve the results of this run later using the /Grids endpoint described below.

    - [GET] https://localhost:8111/Grids/{gridId} - returns the results of a previous run given the unique id returned by the [POST] method for this run.
        
- Notes
    - Swagger is available in development mode.
    - Critical parts of the system are covered by tests
