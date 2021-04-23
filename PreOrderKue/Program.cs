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
            List<CakeName> cakes = new List<CakeName>();
            cakes.Add(new CakeName(1, "Red Velvet", 45000, 5));
            cakes.Add(new CakeName(2, "Matcha", 30000, 7));
            
            while(true)
            {
                Console.WriteLine("\n++++++MENU UTAMA++++++");
                Console.WriteLine("1. Tambah Jenis Produk");
                Console.WriteLine("2. ReStock Produk");
                Console.WriteLine("3. Hapus Produk");
                Console.WriteLine("4. List Produk");
                Console.WriteLine("5. Beli Produk");
                Console.WriteLine("6. History Pembelian");

                int pilihMenu = Convert.ToInt32(Console.ReadLine());

                switch(pilihMenu)
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

                        cakes.Add(new CakeName(newId, newName, newPrice, newAvailability));

                        Console.WriteLine("\nPenambahan Produk Berhasil !!");
                        break;
                    case 2:
                        Console.WriteLine("Pilih Produk yang ingin ditambahkan : ");
                        int restock = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Produk yang akan ditambahkan adalah\n");
                        Console.WriteLine($"Nama Produk         : {cakes[restock - 1].Name}");
                        Console.WriteLine($"Ketersediaan barang : {cakes[restock - 1].Availability}");

                        Console.WriteLine("Masukan jumlah yang ingin ditambahkan : ");
                        int amount = Convert.ToInt32(Console.ReadLine());
                        cakes[restock - 1].Availability = cakes[restock - 1].Availability + amount;
                        Console.WriteLine("\nJumlah barang berhasil ditambahkan...");
                        break;
                    case 3:
                        Console.WriteLine("\nMasukan ID Produk yang akan dihapus :");
                        int deleteProduk = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            cakes.RemoveAt(deleteProduk - 1);
                            Console.WriteLine("\nPenghapusan Produk Berhasil !!");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Error : ID tidak tersedia");
                            continue;
                        }                      
                        
                        break;
                    case 4:
                        Console.WriteLine("List Produk Tersedia");
                        foreach (CakeName cn in cakes)
                        {
                            if (cn.Availability == 0)
                            {
                                continue;
                            }
                            else
                            {
                                Console.WriteLine($"ID : {cn.IdProduk}");
                                Console.WriteLine($"Nama : {cn.Name}");
                                Console.WriteLine($"Harga : {cn.Price}");
                                Console.WriteLine($"Ketersediaan : {cn.Availability}\n");
                            }                                                    
                        }
                        break;
                    case 5:
                        Console.WriteLine("Nama Pembeli : ");
                        string name = Console.ReadLine();

                        Console.WriteLine("Pilih Produk : ");
                        int choose = Convert.ToInt32(Console.ReadLine());
                        CakeName cake = cakes.ElementAt(choose - 1);

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
                            Console.WriteLine($"Anda secara otomatis membeli");
                            Console.WriteLine($"Jumlah barang yang tersedia : {cake.Availability}\n");
                            Console.WriteLine($"Nama Produk        : {cake.Name}");
                            Console.WriteLine($"Jumlah yang dibeli : {cake.Availability}");                          
                            int totals = cake.Availability * cake.Price;                                               
                            Console.WriteLine($"Total Pembayaran   : {totals}");
                            Buyer buyer = new Buyer(name, item, totals);
                            cake.Buyers.Add(buyer);
                            cake.Availability = cake.Availability - cake.Availability;
                        }
                        break;
                    case 6:
                        Console.WriteLine("\nHistory Pembelian\n");
                        foreach (CakeName cn in cakes)
                        {
                            cn.ListPembeli();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
