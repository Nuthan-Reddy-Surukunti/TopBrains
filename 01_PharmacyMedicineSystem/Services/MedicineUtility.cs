using System.Collections.Generic;
using Domain;
using Exceptions;
// using Domain;
namespace Services
{
    public class MedicineUtility
    {
        public static SortedDictionary<int,List<Medicine>> AvailableMedicines = new SortedDictionary<int, List<Medicine>>();
        public void AddMedicine(Medicine medicine)
        {
            if(medicine.ExpiryYear<2026) throw new InvalidExpiryYearException("Expire should be greater than 2026");
            if (AvailableMedicines.ContainsKey(medicine.ExpiryYear))
            {
                var check = AvailableMedicines[medicine.ExpiryYear].Any(i=>i.Id==medicine.Id);
                if(check) throw new DuplicateMedicineException("Medicine already exist");
                AvailableMedicines[medicine.ExpiryYear].Add(medicine);
            }
            else
            {
                AvailableMedicines[medicine.ExpiryYear]= new List<Medicine>(){medicine};
            }
        }
        public void GetAllMedicines()
        {
            if(AvailableMedicines.Count==0) throw new MedicineNotFoundException("No medicines are added");
            foreach(var medicine in AvailableMedicines)
            {
                Console.WriteLine(medicine.Key);
                foreach(var i in medicine.Value)
                {
                    Console.WriteLine($"{i.Id} {i.Name} {i.Price} {i.ExpiryYear}");
                }
            }

        }
        public void UpdateMedicinePrice(string id ,int newPrice)
        {
            if(newPrice<0) throw new InvalidPriceException("Price must be greater than 0");
            var query = AvailableMedicines.SelectMany(i=>i.Value).FirstOrDefault(g=>g.Id==id);
            if (query != null)
            {
                query.Price=newPrice;
            }
            else throw new MedicineNotFoundException($"For updating Price there is no medicine refers this Id: {id}");
        }
    }
}
