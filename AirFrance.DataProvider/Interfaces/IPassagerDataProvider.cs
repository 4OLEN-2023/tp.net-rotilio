using System.Collections.Generic;
using AirFrance.Model;

namespace AirFrance.DataProvider.Interfaces
{
    public interface IPassagerDataProvider
    {
        Passager? GetMyPassager();
        IEnumerable<Passager>? GetMyPassagers();
        Passager? GetPassagerById(int passagerId);
        void Add(Passager passager);
        void Update(Passager passager);
    }
}
