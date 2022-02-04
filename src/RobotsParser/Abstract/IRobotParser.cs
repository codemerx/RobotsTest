﻿using RobotsModel;

namespace RobotsParser.Abstract
{
    public interface IRobotParser
    {
        Robot Parse(string robot, string delimiter);
    }
}
