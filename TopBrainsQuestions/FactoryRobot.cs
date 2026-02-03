public class RobotHazardAuditor
{
    public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState) 
    { 
        if (armPrecision < 0.0 || armPrecision > 1.0) throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0"); 
        if (workerDensity < 1 || workerDensity > 20) throw new RobotSafetyException("Error: Worker density must be 1-20"); 
        double machineRiskFactor=0;
        switch (machineryState)
        {
            case "worn":
                machineRiskFactor=1.3;
                break;
            case "faulty":
                machineRiskFactor=2.0;
                break;
            case "critical":
                machineRiskFactor=3.0;
                break;
            default:
                throw new RobotSafetyException("Error: Machinery state must be Worn/Faulty/Critical");
        }
        return ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor); 
    }
}
public class RobotSafetyException : Exception
{
    public RobotSafetyException(string message):base(message){}
}
class Program
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Enter Arm Precision(0.0-1.0):");
            double armPrecision=double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Worker Density(1-20):");
            int workerDensity=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Machinery State(Worn/Faulty/Critical):");
            string machineryState=Console.ReadLine();
            RobotHazardAuditor robotHazardAuditor = new RobotHazardAuditor();
            Console.WriteLine($"Robot Hazard Risk Score: {robotHazardAuditor.CalculateHazardRisk(armPrecision,workerDensity,machineryState)}");
        }
        catch(RobotSafetyException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}