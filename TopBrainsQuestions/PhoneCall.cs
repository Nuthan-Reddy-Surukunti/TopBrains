// public class PhoneCall
// {
//     public delegate void Notify();
//     public event Notify PhoneCallEvent;
//     public  string Message { get; private set; }
//     private void OnSubscribed()
//     {
//         Message = "Subscribed to Call";
//         Console.WriteLine(Message);
//     }
//     private void OnUnSubscribed()
//     {
//         Message = "UnSubscribed to Call";
//         Console.WriteLine(Message);   
//     }
//     public void MakeAPhoneCall(bool notify)
//     {
//         PhoneCallEvent = null;
//         if (notify)
//         {
//             PhoneCallEvent+=OnSubscribed;
//         }
//         else
//         {
//            PhoneCallEvent+=OnUnSubscribed;
//         }
//         PhoneCallEvent?.Invoke();
        
//     }
//     public static void Main()
//     {
//         PhoneCall phoneCall = new PhoneCall();
//         phoneCall.MakeAPhoneCall(true);
//         phoneCall.MakeAPhoneCall(false);
        
//     }
// }
