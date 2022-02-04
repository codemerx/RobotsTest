# RobotsTest

- How to run the project
  - VS 2022 is needed because the project is on dotnet 6
  - Run the command "update-database" in the package manager console in order to apply the migrations
  - Run the API
- How to test the API
  - When the app is running a swagger page will be opened. You can use swagger or for example, Postman to make HTTP requests.
  - There are two implemented endpoints: [POST] /Grid and [GET] /Grid/{gridId}
  - The format should be JSON. We have decided to use the sample input format from the problem however there are no newlines in JSON, so instead of a newline should be used /r/n
  - Sample input for [POST] /Grid - {"input": "5 3\r\n1 1 E\r\nRFRFRFRF\r\n3 2 N\r\nFRRFLLFFRRFLL\r\n0 3 W\r\nLLFFFRFLFL"}
- How to run the tests
  - There is nothing specific, go to test explorer and run them all
  
