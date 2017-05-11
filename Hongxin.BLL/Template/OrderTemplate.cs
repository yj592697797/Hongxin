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
                sheet.Rows.RowHeight = 22;
                sheet.Columns.ColumnWidth = 5;

                excel.UniteCells(sheet, 1, 1, 1, 16);
                excel.UniteCells(sheet, 2, 1, 2, 15);
                excel.UniteCells(sheet, 3, 1, 3, 19);
                excel.UniteCells(sheet, 5, 1, 5, 15);
                excel.UniteCells(sheet, 6, 1, 6, 3);
                excel.UniteCells(sheet, 6, 4, 6, 15);
                excel.UniteCells(sheet, 7, 1, 7, 3);
                excel.UniteCells(sheet, 7, 4, 7, 7);
                excel.UniteCells(sheet, 8, 1, 8, 3);
                excel.UniteCells(sheet, 8, 4, 8, 7);
                excel.UniteCells(sheet, 9, 1, 9, 3);
                excel.UniteCells(sheet, 9, 4, 9, 7);
                excel.UniteCells(sheet, 9, 8, 9, 15);
                excel.UniteCells(sheet, 10, 1, 10, 3);
                excel.UniteCells(sheet, 10, 4, 10, 7);
                excel.UniteCells(sheet, 11, 1, 11, 3);
                excel.UniteCells(sheet, 11, 4, 11, 7);
                excel.UniteCells(sheet, 11, 8, 11, 10);
                excel.UniteCells(sheet, 11, 11, 11, 14);
                excel.SetCellProperty(sheet, 1, 1, 1, 16, 20, "宋体", true, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlCenter);
                excel.SetCellProperty(sheet, 2, 1, 2, 15, 12, "宋体", true, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlCenter);
                excel.SetCellProperty(sheet, 3, 1, 3, 19, 9, "宋体", true, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlCenter);
                excel.SetCellProperty(sheet, 5, 1, 5, 15, 18, "宋体", true, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlCenter);
                excel.SetCellProperty(sheet, 6, 1, 11, 3, 16, "宋体", true, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlRight);
                excel.SetCellProperty(sheet, 6, 4, 11, 7, 16, "宋体", true, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlLeft);
                excel.SetCellProperty(sheet, 9, 8, 9, 15, 16, "宋体", true, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlCenter);
                excel.SetCellProperty(sheet, 11, 8, 11, 10, 16, "宋体", true, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlRight);
                excel.SetCellProperty(sheet, 11, 11, 11, 14, 16, "宋体", true, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlLeft);

                excel.SetCellValue(sheet, 1, 1, "东莞市黄江红兴木业制品有限公司");
                excel.SetCellValue(sheet, 2, 1, "Dongguan Huang Jiang Hongxing Wood Products Co., Ltd.");
                excel.SetCellValue(sheet, 3, 1, "广东省东莞市黄江星光福星路1号 TEL：0769-89392278 FAX:0769:87006238 E-MAIL:dghx118@163.COM");
                excel.SetCellValue(sheet, 5, 1, "采购单");
                excel.SetCellValue(sheet, 6, 1, "供 应 商：");
                excel.SetCellValue(sheet, 6, 4, order.Supplier);
                excel.SetCellValue(sheet, 7, 1, "联 系 人：");
                excel.SetCellValue(sheet, 7, 4, order.LinkPerson);
                excel.SetCellValue(sheet, 8, 1, "联系电话：");
                excel.SetCellValue(sheet, 8, 4, order.Phone);
                excel.SetCellValue(sheet, 9, 1, "电    话：");
                excel.SetCellValue(sheet, 9, 4, order.Tel);
                excel.SetCellValue(sheet, 9, 8, order.OrderNo);
                excel.SetCellValue(sheet, 10, 1, "传    真：");
                excel.SetCellValue(sheet, 10, 4, order.Fax);
                excel.SetCellValue(sheet, 11, 1, "下单日期：");
                excel.SetCellValue(sheet, 11, 4, order.OrderDate.ToString("yyyy-MM-dd"));
                excel.SetCellValue(sheet, 11, 8, "交货日期：");
                excel.SetCellValue(sheet, 11, 11, order.DeliveryDate.ToString("yyyy-MM-dd"));

                int row = 13;
                int table_rows = details.Count;
                int table_cols = 15;
                excel.SetCellProperty_Table(sheet, row, 1, row + table_rows, table_cols);
                excel.SetCellProperty(sheet, row, 1, row, table_cols, 12, "宋体", true, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlCenter);
                excel.SetCellProperty(sheet, row + 1, 1, row + table_rows, table_cols, 12, "宋体", false, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlCenter);
                excel.SetCellProperty_WrapText(sheet, row, 1, row + table_rows, table_cols, true);

                excel.UniteCells(sheet, row, 2, row, 6);
                excel.UniteCells(sheet, row, 8, row, 9);
                excel.UniteCells(sheet, row, 10, row, 15);
                excel.SetCellValue(sheet, row, 1, "序号");
                excel.SetCellValue(sheet, row, 2, "品名规格");
                excel.SetCellValue(sheet, row, 7, "单位");
                excel.SetCellValue(sheet, row, 8, "数量");
                excel.SetCellValue(sheet, row, 10, "备注");
                foreach (var det in details)
                {
                    row++;
                    excel.UniteCells(sheet, row, 2, row, 6);
                    excel.UniteCells(sheet, row, 8, row, 9);
                    excel.UniteCells(sheet, row, 10, row, 15);
                    excel.SetCellValue(sheet, row, 1, det.SortIndex);
                    excel.SetCellValue(sheet, row, 2, det.Name + det.Size);
                    excel.SetCellValue(sheet, row, 7, det.Unit);
                    excel.SetCellValue(sheet, row, 8, det.Total);
                    excel.SetCellValue(sheet, row, 10, det.Remark);
                }

                row = row + 2;
                int contract_rows = 7;
                int contract_cols = 15;
                excel.UniteCells(sheet, row, 1, row + contract_rows, contract_cols);
                excel.SetCellProperty(sheet, row, 2, row + contract_rows, contract_cols, 12, "宋体", false, Microsoft.Office.Interop.Excel.Constants.xlTop, Microsoft.Office.Interop.Excel.Constants.xlLeft);
                excel.SetCellProperty_WrapText(sheet, row, 2, row + contract_rows, contract_cols, true);
                excel.SetCellValue(sheet, row, 1, order.Contract);

                row = row + contract_rows + 2;
                excel.UniteCells(sheet, row, 3, row, 4);
                excel.SetCellValue(sheet, row, 3, "确认签字：");
                excel.SetCellProperty(sheet, row, 3, row, 4, 12, "宋体", false, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlRight);
                excel.UniteCells(sheet, row, 5, row, 6);
                excel.SetCellProperty_Border_Bottom(sheet, row, 5, row,6);
                excel.SetCellProperty(sheet, row, 5, row, 6, 12, "宋体", false, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlLeft);
                excel.UniteCells(sheet, row, 12, row, 13);
                excel.SetCellValue(sheet, row, 12, "制表：");
                excel.SetCellProperty(sheet, row, 12, row, 13, 12, "宋体", false, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlRight);
                excel.UniteCells(sheet, row, 14, row, 15);
                excel.SetCellProperty_Border_Bottom(sheet, row, 14, row, 15);
                excel.SetCellProperty(sheet, row, 14, row, 15, 12, "宋体", false, Microsoft.Office.Interop.Excel.Constants.xlCenter, Microsoft.Office.Interop.Excel.Constants.xlLeft);

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
