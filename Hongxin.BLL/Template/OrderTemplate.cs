using Hongxin.Core.Helper;
using Hongxin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hongxin.BLL.Template
{
    public class OrderTemplate
    {
        public static string Create(OrderRecord order, List<OrderDetailRecord> details)
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory + "Temp/";
            string sheetName = "采购单";
            string fileName = appPath + DateTime.Now.ToString("yyyyMMddHHmmss_")  + "采购单.xlsx";

            order.Contract = order.Contract.Replace("<p>", "").Replace("</p>", "\n").Replace("<br>", "\n");

            ExcelHelper excel = new ExcelHelper();
            try
            {

                excel.Create();
                var sheet = excel.AddSheet(sheetName);
                excel.UniteCells(sheet, 6, 1, 6, 2);
                excel.UniteCells(sheet, 6, 3, 6, 10);
                excel.UniteCells(sheet, 7, 1, 7, 2);
                excel.UniteCells(sheet, 7, 3, 7, 5);
                excel.UniteCells(sheet, 8, 1, 8, 2);
                excel.UniteCells(sheet, 8, 3, 8, 5);
                excel.UniteCells(sheet, 9, 1, 9, 2);
                excel.UniteCells(sheet, 9, 3, 9, 5);
                excel.UniteCells(sheet, 9, 6, 9, 10);
                excel.UniteCells(sheet, 10, 1, 10, 2);
                excel.UniteCells(sheet, 10, 3, 10, 5);
                excel.UniteCells(sheet, 11, 1, 11, 2);
                excel.UniteCells(sheet, 11, 3, 11, 5);
                excel.UniteCells(sheet, 11, 6, 11, 7);
                excel.UniteCells(sheet, 11, 8, 11, 10);
                excel.SetCellProperty_RowHeight(sheet, 1, 1, 100, 20, 22);
                excel.SetCellProperty(sheet, 6, 1, 11, 2, 16, "宋体", true, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlRight, 22);
                excel.SetCellProperty(sheet, 6, 3, 11, 5, 16, "宋体", true, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlLeft, 22);
                excel.SetCellProperty(sheet, 9, 6, 9, 10, 16, "宋体", true, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlCenter, 22);
                excel.SetCellProperty(sheet, 11, 6, 11, 7, 16, "宋体", true, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlRight, 22);
                excel.SetCellProperty(sheet, 11, 8, 11, 10, 16, "宋体", true, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlLeft, 22);

                excel.SetCellValue(sheet, 6, 1, "供应商：");
                excel.SetCellValue(sheet, 6, 3, order.Supplier);
                excel.SetCellValue(sheet, 7, 1, "联系人：");
                excel.SetCellValue(sheet, 7, 3, order.LinkPerson);
                excel.SetCellValue(sheet, 8, 1, "联系电话：");
                excel.SetCellValue(sheet, 8, 3, order.Phone);
                excel.SetCellValue(sheet, 9, 1, "电话：");
                excel.SetCellValue(sheet, 9, 3, order.Tel);
                excel.SetCellValue(sheet, 9, 6, order.OrderNo);
                excel.SetCellValue(sheet, 10, 1, "传真：");
                excel.SetCellValue(sheet, 10, 3, order.Fax);
                excel.SetCellValue(sheet, 11, 1, "下单日期：");
                excel.SetCellValue(sheet, 11, 3, order.OrderDate.ToString("yyyy-MM-dd"));
                excel.SetCellValue(sheet, 11, 6, "交货日期：");
                excel.SetCellValue(sheet, 11, 8, order.DeliveryDate.ToString("yyyy-MM-dd"));

                int row = 13;
                int table_rows = details.Count;
                excel.SetCellProperty_Table(sheet, row, 2, row + table_rows, 20);
                excel.SetCellProperty(sheet, row, 2, row, 20, 12, "宋体", true, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlCenter, 22);
                excel.SetCellProperty(sheet, row + 1, 2, row + table_rows, 20, 12, "宋体", false, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlCenter, 22);

                excel.UniteCells(sheet, row, 3, row, 5);
                excel.UniteCells(sheet, row, 6, row, 8);
                excel.UniteCells(sheet, row, 10, row, 11);
                excel.UniteCells(sheet, row, 12, row, 20);
                excel.SetCellValue(sheet, row, 2, "序号");
                excel.SetCellValue(sheet, row, 3, "品名");
                excel.SetCellValue(sheet, row, 6, "规格");
                excel.SetCellValue(sheet, row, 9, "单位");
                excel.SetCellValue(sheet, row, 10, "数量");
                excel.SetCellValue(sheet, row, 12, "备注");
                foreach (var det in details)
                {
                    row++;
                    excel.UniteCells(sheet, row, 3, row, 5);
                    excel.UniteCells(sheet, row, 6, row, 8);
                    excel.UniteCells(sheet, row, 10, row, 11);
                    excel.UniteCells(sheet, row, 12, row, 20);
                    excel.SetCellValue(sheet, row, 2, det.SortIndex);
                    excel.SetCellValue(sheet, row, 3, det.Name);
                    excel.SetCellValue(sheet, row, 6, det.Size);
                    excel.SetCellValue(sheet, row, 9, det.Unit);
                    excel.SetCellValue(sheet, row, 10, det.Total);
                    excel.SetCellValue(sheet, row, 12, det.Remark);
                }

                row = row + 2;
                int contract = 7;
                excel.UniteCells(sheet, row, 2, row + contract, 16);
                excel.SetCellProperty(sheet, row, 2, row + contract, 16, 12, "宋体", false, Microsoft.Office.Interop.Excel.Constants.xlTop, Microsoft.Office.Interop.Excel.Constants.xlLeft, 22);
                excel.SetCellProperty_WrapText(sheet, row, 2, row + contract, 16, true);
                excel.SetCellValue(sheet, row, 2, order.Contract);

                row = row + contract + 2;
                excel.UniteCells(sheet, row, 2, row, 3);
                excel.SetCellValue(sheet, row, 2, "确认签字：");
                excel.SetCellProperty(sheet, row, 2, row, 3, 12, "宋体", false, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlRight, 22);
                excel.UniteCells(sheet, row, 4, row, 5);
                excel.SetCellProperty_Border_Bottom(sheet, row, 4, row, 5);
                excel.SetCellProperty(sheet, row, 4, row, 5, 12, "宋体", false, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlLeft, 22);
                excel.UniteCells(sheet, row, 7, row, 8);
                excel.SetCellValue(sheet, row, 7, "制表：");
                excel.SetCellProperty(sheet, row, 7, row, 8, 12, "宋体", false, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlRight, 22);
                excel.UniteCells(sheet, row, 9, row, 10);
                excel.SetCellProperty_Border_Bottom(sheet, row, 9, row, 10);
                excel.SetCellProperty(sheet, row, 9, row, 10, 12, "宋体", false, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlLeft, 22);

                excel.SaveAs(fileName);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                excel.Close();
            }

            return fileName;
        }
    }
}
