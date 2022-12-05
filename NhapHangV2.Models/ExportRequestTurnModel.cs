using NhapHangV2.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NhapHangV2.Utilities.CoreContants;

namespace NhapHangV2.Models
{
    public class ExportRequestTurnModel : AppDomainModel
    {
        /// <summary>
        /// Tổng tiền (VNĐ)
        /// </summary>
        public decimal? TotalPriceVND { get; set; }

        /// <summary>
        /// Tổng tiền (tệ)
        /// </summary>
        public decimal? TotalPriceCNY { get; set; }

        /// <summary>
        /// Tổng cân nặng
        /// </summary>
        public decimal? TotalWeight { get; set; }

        /// <summary>
        /// Tổng số kiện
        /// </summary>
        public int? TotalPackage { get; set; }

        /// <summary>
        /// Ghi chú của nhân viên
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Id hình thức vận chuyển
        /// </summary>
        public int? ShippingTypeInVNId { get; set; }

        /// <summary>
        /// Tên hình thức vận chuyển
        /// </summary>
        public int? ShippingTypeInVNName { get; set; }

        /// <summary>
        /// UID
        /// </summary>
        public int? UID { get; set; }

        /// <summary>
        /// Tên tài khoản
        /// </summary>

        public string UserName { get; set; }

        /// <summary>
        /// Ghi chú của khách hàng
        /// </summary>
        public string StaffNote { get; set; }

        /// <summary>
        /// Trạng thái thanh toán
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// Tên trạng thái thanh toán
        /// </summary>
        public string StatusName
        {
            get
            {
                switch (Status)
                {
                    case (int)ExportRequestTurnStatus.ChuaThanhToan:
                        return "Chưa thanh toán";
                    case (int)ExportRequestTurnStatus.DaThanhToan:
                        return "Đã thanh toán";
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// Trạng thái xuất kho
        /// </summary>
        public int? StatusExport { get; set; }

        /// <summary>
        /// Tên trạng thái xuất kho
        /// </summary>
        public string StatusExportName
        {
            get
            {
                switch (StatusExport)
                {
                    case (int)ExportRequestTurnStatusExport.ChuaXuatKho:
                        return "Chưa xuất kho";
                    case (int)ExportRequestTurnStatusExport.DaXuatKho:
                        return "Đã xuất kho";
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// Ngày xuất kho
        /// </summary>
        public DateTime? OutStockDate { get; set; }

        public string BarCodeAndDateOut { get; set; }

        public List<BarCodeAndDateOutDetail> BarCodeAndDateOuts
        { 
            get
            {
                var list = new List<BarCodeAndDateOutDetail>();
                if (string.IsNullOrEmpty(BarCodeAndDateOut))
                    return list;
                var detail = BarCodeAndDateOut.Split(';');
                if (detail.Length > 0)
                {
                    for (int i = 0; i < detail.Length; i++)
                    {
                        var smallPackage = detail[i].Split('_');
                        if (smallPackage.Length == 0)
                            continue;
                        list.Add(new BarCodeAndDateOutDetail
                        {
                            OrderTransactionCode = smallPackage[0],
                            DateOutWarehouse = smallPackage[1]
                        });
                    }
                }
                return list;
            }
        }

        public int? Type { get; set; }

        public List<TransportationOrderModel> TransportationOrders { get; set; }

        public List<SmallPackageModel> SmallPackages { get; set; }
    }

    public class BarCodeAndDateOutDetail
    {
        public string OrderTransactionCode { get; set; }
        public string DateOutWarehouse { get; set; }
    }
}
