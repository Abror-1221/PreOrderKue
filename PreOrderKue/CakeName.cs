using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreOrderKue
{
    class CakeName
    {
        public int IdProduk { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Availability { get; set; }

        public List<Buyer> Buyers { get; set; }

        public CakeName(int idProduk, string name, int price, int availability)
        {
            IdProduk = idProduk;
            Name = name;
            Price = price;
            Availability = availability;
            Buyers = new List<Buyer>();
        }

        public void ListPembeli()
        {
            Console.WriteLine("List Pembeli Produk\n");
            foreach(Buyer b in Buyers)
            {
                Console.WriteLine($"Nama Pembeli : {b.NickName}");
                Console.WriteLine($"Jumlah Barang : {b.Ammount}");
                Console.WriteLine($"Total Harga : {b.Total}\n");
            }
        }
    }
}
