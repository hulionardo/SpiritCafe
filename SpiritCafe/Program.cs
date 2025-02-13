using SpiritCafe.Data;
using SpiritCafe.Entities;
using SpiritCafe;

using (var context = new OrderingSystemContext())
        {
            Menu.Start(context);
        }