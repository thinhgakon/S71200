﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using S7;
using S7.Net;
using S7.Net.Types;

namespace S71200
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Địa chỉ IP của PLC
            string ip = "192.168.13.166";
            // Số rack và slot (thường là 0 và 1)
            short rack = 0;
            short slot = 1;

            // Khởi tạo đối tượng PLC
            using (var plc = new Plc(CpuType.S71200, ip, rack, slot))
            {
                // Kết nối tới PLC
                plc.Open();

                if (plc.IsConnected)
                {
                    Console.WriteLine("Kết nối thành công!");

                    //Bật chân Q0.0
                    //plc.Write("Q0.3", true);

                    Thread.Sleep(1000);

                    //plc.Write("Q0.3", false);

                    //plc.Write("Q0.3", true);
                    ////plc.Write("Q0.3", false);

                    //plc.Write("Q0.3", true);
                    plc.Write("Q0.2", false);


                    // Kiểm tra và hiển thị kết quả
                    var result = plc.Read("Q0.3");

                    if (result is bool outputValue && outputValue)
                    {
                        Console.WriteLine("Chân Q0.3 đã được bật.");
                    }
                    else
                    {
                        Console.WriteLine("Không thể bật chân Q0.0.");
                    }


                    // Bật chân I
                    //plc.Write("I0.3", true);

                    //// Tắt chân I
                    //plc.Write("I0.3", false);

                    //// Đọc dữ liệu từ đầu vào I0.0
                    //var readResult = plc.Read("I0.3");

                    ////Kiểm tra và hiển thị kết quả
                    //if (readResult is bool inputValue)
                    //{
                    //    Console.WriteLine($"Giá trị của I0.3 là: {inputValue}");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Đọc giá trị không thành công.");
                    //}

                    // Đóng kết nối
                    plc.Close();
                }
                else
                {
                    Console.WriteLine("Kết nối thất bại.");
                }
            }

            Console.ReadLine();
        }
    }
}
