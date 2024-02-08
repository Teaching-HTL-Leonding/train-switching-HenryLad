namespace TrainSwitching.Logic;

public class TrainStation
{
    public Track[] Tracks { get; }

    public TrainStation()
    {
        Tracks = new Track[10];

        for (int i = 0; i < 10; i++)
        {
            Tracks[i] = new Track();
        }
    }

    /// <summary>
    /// Tries to apply the given operation to the train station.
    /// </summary>
    /// <param name="op">Operation to apply</param>
    /// <returns>Returns true if the operation could be applied, otherwise false</returns>
    public bool TryApplyOperation(SwitchingOperation op)
    {
        if (op.TrackNumber == 9 || op.TrackNumber == 10 && op.Direction == 1) { return false; }
        if (op.TrackNumber <= 0 || op.TrackNumber >= 11) { return false; }
        if (Tracks[op.TrackNumber - 1].Wagons.Count < op.NumberOfWagons) { return false; }
        if (op.NumberOfWagons == 0 && op.OperationType == Constants.OPERATION_TRAIN_LEAVE) { return false; }
        if (op.NumberOfWagons < Constants.OPERATION_REMOVE) { return false; }
        if (op.OperationType == Constants.OPERATION_TRAIN_LEAVE && !Tracks[op.TrackNumber - 1].Wagons.Contains(Constants.WAGON_TYPE_LOCOMOTIVE)) { return false; }
        if (op.OperationType == Constants.OPERATION_TRAIN_LEAVE && Tracks[op.TrackNumber - 1].Wagons.Count == 0) { return false; }
        if (op.OperationType == Constants.OPERATION_ADD)
        {
            if (op.Direction == Constants.DIRECTION_EAST)
            {
                Tracks[op.TrackNumber - 1].Wagons.Add(op.WagonType!.Value);
            }
            else
            {
                Tracks[op.TrackNumber - 1].Wagons.Insert(0, op.WagonType!.Value);
            }


        }
        else if (op.OperationType == Constants.OPERATION_REMOVE)
        {

            if (op.Direction == Constants.DIRECTION_EAST)
            {
                for (int i = 0; i < op.NumberOfWagons; i++)
                {
                    Tracks[op.TrackNumber - 1].Wagons.RemoveAt(Tracks[op.TrackNumber - 1].Wagons.Count - 1);
                }
            }
            else
            {
                for (int i = 0; i < op.NumberOfWagons; i++)
                {
                    Tracks[op.TrackNumber - 1].Wagons.RemoveAt(0);
                }
            }
        }

        else if (op.OperationType == Constants.OPERATION_TRAIN_LEAVE)
        {
            Tracks[op.TrackNumber - 1].Wagons.Clear();

        }
        return true;
    }

    /// <summary>
    /// Calculates the checksum of the train station.
    /// </summary>
    /// <returns>The calculated checksum</returns>
    /// <remarks>
    /// See readme.md for details on how to calculate the checksum.
    /// </remarks>
    public int CalculateChecksum()
    {
        // TODO: Implement this method
        throw new NotImplementedException();
    }
}