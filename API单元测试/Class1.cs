using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XINJE;
using NUnit.Framework;

namespace API单元测试
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test, Order(1)]
        // 测试mc_connect_open函数的connectNo参数
        [TestCase((ushort)1, (ushort)20013)]//20013=通讯端口号超出范围
        [TestCase((ushort)0, (ushort)0)]
        public void Test1_mc_connect_open_TestParam_connectNo(ushort connectNo, ushort expectedErrorCode)
        {
            ushort errorCode = XINJEMC.mc_connect_open(connectNo, 1,"192.168.6.6",1000);
            Assert.That(errorCode, Is.EqualTo(expectedErrorCode));
            ushort errorCode1 = XINJEMC.mc_connect_close(0);

        }

        [Test, Order(1)]
        // 测试mc_connect_open函数的ip参数
        [TestCase("192.168.6.7", (ushort)20008)]//20008=socket通讯失败
        [TestCase("192.168.256.6", (ushort)20008)]//20008=socket通讯失败
        [TestCase("192.168.6.6", (ushort)0)]
        public void Test1_mc_connect_open_TestParam_ip(string ipaddr, ushort expectedErrorCode)
        {
            ushort errorCode = XINJEMC.mc_connect_open(0, 1, ipaddr, 1000);
            Assert.That(errorCode, Is.EqualTo(expectedErrorCode));
            ushort errorCode1 = XINJEMC.mc_connect_close(0);
        }

        [Test, Order(2)]
        // 测试mc_connect_open函数的type参数      
        [TestCase((ushort)2, (ushort)20000)]//20000=错误的通讯类型
        [TestCase((ushort)0, (ushort)0)]
        [TestCase((ushort)1, (ushort)0)]
        public void Test1_mc_connect_open_TestParam_type(ushort type, ushort expectedErrorCode)
        {
            ushort errorCode = XINJEMC.mc_connect_open( 0, type,"192.168.6.6", 1000);
            Assert.That(errorCode, Is.EqualTo(expectedErrorCode));
        }

        /*
        // 测试mc_connect_open函数的dwBaudRate参数(目前不支持，跳过）
 
        public void Test_mc_connect_open_TestParam_dwBaudRate(uint dwBaudRate, ushort expectedErrorCode)
        {
            ushort errorCode = XINJEMC.mc_connect_open(connectNo: 0, type, pconnectstring: "192.168.6.6", dwBaudRate);
            Assert.That(errorCode, Is.EqualTo(expectedErrorCode));
        }*/

        [Test, Order(3)]//建立通讯后执行使能
        // 测试mc_connect_open函数的connectNo参数
        [TestCase((ushort)1, (ushort)20013)]//20013=通讯端口号超出范围
        [TestCase((ushort)0, (ushort)0)]
        public void Test2_mc_connect_enable_TestParam_connectNo(ushort connectNo, ushort expectedErrorCode)
        {
            ushort errorCode = XINJEMC.mc_axis_enable(connectNo,0);
            Assert.That(errorCode, Is.EqualTo(expectedErrorCode));
        }

        [Test, Order(1)]//建立通讯前执行使能
        // 测试mc_connect_open函数的axisId参数
        public void Test2_mc_connect_enable_TestParam_axisId0()
        {
            ushort i = 0;
            for (i = 0; i < 2; i++)
            {
                ushort errorCode = XINJEMC.mc_axis_enable(0, i);
                Assert.That(errorCode, Is.EqualTo(20001));//20001=连接失败
            }
        }

        [Test, Order(3)]//建立通讯后执行使能
        // 测试mc_connect_open函数的axisId参数
        public void Test2_mc_connect_enable_TestParam_axisId1()
        {
            ushort j = 0;
            for (j = 0; j <2; j++)
            {
                ushort errorCode = XINJEMC.mc_axis_enable(0, j);
                Assert.That(errorCode, Is.EqualTo(0));
            }
            
        }
    }
}

