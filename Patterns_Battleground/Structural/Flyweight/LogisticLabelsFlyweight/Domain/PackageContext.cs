namespace Patterns_Battleground.Structural.Flyweight.LogisticLabelsFlyweight.Domain
{
    public record PackageContext
    {

        public int PackageId { get; init; }
        public string Destination { get; init; }
        public string PositionOnPallet { get; init; }
        public string DispatchDate { get; init; }
        public string HandlingInstructions { get; init; }

        public PackageContext(int packageId, string destination, string positionOnPallet, string dispatchDate, string handlingInstructions)
        {
            PackageId = packageId;
            Destination = destination;
            PositionOnPallet = positionOnPallet;
            DispatchDate = dispatchDate;
            HandlingInstructions = handlingInstructions;
        }
    }
}
