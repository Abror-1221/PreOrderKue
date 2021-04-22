using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreOrderKue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("++++++Selamat Datang++++++");
            List<CakeName> Cakes = new List<CakeName>();
            Cakes.Add(new CakeName(1, "Red Velvet", 45000, 5));
            Cakes.Add(new CakeName(2, "Matcha", 30000, 7));

            while(true)
            {
                Console.WriteLine("++++++MENU UTAMA++++++");
                Console.WriteLine("1. Tambah Jenis Produk");
                Console.WriteLine("2. Hapus Produk");
                Console.WriteLine("3. List Produk");
                Console.WriteLine("4. Beli Produk");
                int PilihMenu = Convert.ToInt32(Console.ReadLine());

                switch(PilihMenu)
                {
                    case 1:                       
                        Console.WriteLine("\nMasukan ID Produk :");
                        int newId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Masukan Nama Produk :");
                        string newName = Console.ReadLine();
                        Console.WriteLine("Masukan Harga Produk :");
                        int newPrice = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Masukan Ketersediaan Produk :");
                        int newAvailability = Convert.ToInt32(Console.ReadLine());

                        Cakes.Add(new CakeName(newId, newName, newPrice, newAvailability));

                        Console.WriteLine("\nPenambahan Produk Berhasil !!");
                        break;
                    case 2:
                        Console.WriteLine("\nMasukan ID Produk yang akan dihapus :");
                        int deleteProduk = Convert.ToInt32(Console.ReadLine());

                        Cakes.RemoveAt(deleteProduk);

                        Console.WriteLine("\nPenghapusan Produk Berhasil !!");
                        break;
                    case 3:
                        Console.WriteLine("List Produk Tersedia Beserta Pembelinya");

                        foreach (CakeName cn in Cakes)
                        {
                            if (cn.Availability == 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"ID : {cn.IdProduk}");
                                Console.WriteLine($"Nama : {cn.Name}");
                                Console.WriteLine($"Harga : {cn.Price}");
                                Console.WriteLine($"Ketersediaan : {cn.Availability}\n");
                            }                         
                            cn.ListPembeli();
                        }
                        break;
                    case 4:
                        Console.WriteLine("Nama Pembeli : ");
                        string name = Console.ReadLine();

                        Console.WriteLine("Pilih Produk : ");
                        int choose = Convert.ToInt32(Console.ReadLine());
                        CakeName cake = Cakes.ElementAt(choose - 1);

                        Console.WriteLine($"Nama Produk : {cake.Name}");
                        Console.WriteLine($"Harga Barang : {cake.Price}\n");
                      
                        Console.WriteLine("Jumlah Barang : ");
                        int item = Convert.ToInt32(Console.ReadLine());

                        if (item <= cake.Availability)
                        {
                            cake.Availability = cake.Availability - item;
                            int totals = item * cake.Price;
                            Buyer buyer = new Buyer(name, item, totals);                          
                            Console.WriteLine($"Total Pembayaran : {totals}\n");
                            cake.Buyers.Add(buyer);
                            Console.WriteLine("ORDER BERHASIL TERSIMPAN !!\n\n");
                        }
                        else
                        {
                            Console.WriteLine("==Barang Tidak Tercukupi==\n\n");
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
