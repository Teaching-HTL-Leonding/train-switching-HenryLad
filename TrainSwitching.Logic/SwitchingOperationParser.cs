namespace TrainSwitching.Logic;

public static class SwitchingOperationParser
{
    /// <summary>
    /// Parses a line of input into a <see cref="SwitchingOperation"/>.
    /// </summary>
    /// <param name="inputLine">Line to parse. See readme.md for details</param>
    /// <returns>The parsed switching operation</returns>
    public static SwitchingOperation Parse(string inputLine)
    { 
        
        var output = new SwitchingOperation();

        var parts = inputLine.Split(", ");

        output.TrackNumber = int.Parse(parts[0].Split(" ")[2]);

        if (parts[1].StartsWith("add")) { output.OperationType = Constants.OPERATION_ADD; }
        else if (parts[1].StartsWith("remove")) { output.OperationType = Constants.OPERATION_REMOVE; }
        else if (parts[1].StartsWith("train leaves")) { output.OperationType = Constants.OPERATION_TRAIN_LEAVE; }

        if (parts[1].EndsWith("West")) { output.Direction = Constants.DIRECTION_WEST; }
        else if (parts[1].EndsWith("East")) { output.Direction = Constants.DIRECTION_EAST; }

        if (output.OperationType == Constants.OPERATION_ADD)
        {
            if(parts[1].Contains("Locomotive")) { output.WagonType = Constants.WAGON_TYPE_LOCOMOTIVE; }
            else if(parts[1].Contains("Passenger")) { output.WagonType = Constants.WAGON_TYPE_PASSENGER; }
            else if(parts[1].Contains("Freight")) { output.WagonType = Constants.WAGON_TYPE_FREIGHT; }
            else if(parts[1].Contains("Car Transport")) { output.WagonType = Constants.WAGON_TYPE_CAR_TRANSPORT; }
        }

        if (output.OperationType == Constants.OPERATION_REMOVE)
        {
            output.NumberOfWagons = int.Parse(parts[1].Split(" ")[1]);
        }

        return output;




    }
}