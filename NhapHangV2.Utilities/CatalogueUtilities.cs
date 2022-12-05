using System;
using System.Collections.Generic;
using System.Text;

namespace NhapHangV2.Utilities
{
    public class CatalogueUtilities
    {

    }

    public class AmountStatistic
    {
        public decimal? TotalOrderPrice { get; set; }
        public decimal? TotalPaidPrice { get; set; }
    }

    public class MainOrdersInfor
    {
        /// <summary>
        /// Tổng số đơn hàng 
        /// </summary>
        public int TotalOrders { get; set; }
        /// <summary>
        /// Đơn hàng chưa đặt cọc
        /// </summary>
        public int TotalUnpaidOrders { get; set; }
        /// <summary>
        /// Đơn hàng đã đặt cọc
        /// </summary>
        public int ToTalPaidOrders { get; set; }
        /// <summary>
        /// Đơn hàng đã đặt hàng
        /// </summary>
        public int ToTalPlacedOrders { get; set; }
        /// <summary>
        /// Đơn hàng đã có tại kho TQ
        /// </summary>
        public int TotalInChinaOrders { get; set; }
        /// <summary>
        /// Đơn hàng đã có tại kho VN
        /// </summary>
        public int TotalInVietnamOrders { get; set; }
        /// <summary>
        /// Đơn hàng đã nhận
        /// </summary>
        public int TotalReceivedOrders { get; set; }
    }
    public class MainOrdersAmount
    {
        /// <summary>
        /// Tổng tiền hàng chưa giao
        /// </summary>
        public decimal AmountNotDelivery { get; set; }
        /// <summary>
        /// Tổng tiền hàng cần đặt cọc
        /// </summary>
        public decimal AmountMustDeposit { get; set; }
        /// <summary>
        /// Tổng tiền hàng (đơn hàng cần đặt cọc)
        /// </summary>
        public decimal AmountOrderRequireDeposit { get; set; }
        /// <summary>
        /// Tổng tiền hàng chờ về kho TQ
        /// </summary>
        public decimal AmoutWattingToChina { get; set; }
        /// <summary>
        /// Tổng tiền hàng đã về kho TQ
        /// </summary>
        public decimal AmountInChina { get; set; }
        /// <summary>
        /// Tổng tiền hàng đang ở kho đích
        /// </summary>
        public decimal AmountInVietnam { get; set; }
        /// <summary>
        /// Tổng tiền cần thanh toán để lấy hàng trong kho
        /// </summary>
        public decimal AmountPay { get; set; }
    }

    public class BillInfor
    {
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Địa chỉ người dùng
        /// </summary>
        public string UserAddress { get; set; }

        /// <summary>
        /// Tiền bằng chữ
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Tiền bằng chữ
        /// </summary>
        public string AmountString
        {
            get
            {
                return ConvertAmountToSentence.NumberToText(Amount);
            }
        }

        /// <summary>
        /// Lý do
        /// </summary>
        public string Note { get; set; }

    }

    /// <summary>
    /// Số lượng các đơn hàng theo trạng thái
    /// </summary>
    public class NumberOfOrders
    {
        /// <summary>
        /// Tất cả
        /// </summary>
        public decimal? AllOrders { get; set; }
        /// <summary>
        /// Chưa đặt cọc
        /// </summary>
        public decimal? UnDeposit { get; set; }
        /// <summary>
        /// Hủy
        /// </summary>
        public decimal? Cancel { get; set; }
        /// <summary>
        /// Đã đặt cọc
        /// </summary>
        public decimal? Deposit { get; set; }
        /// <summary>
        /// Chờ duyệt đơn
        /// </summary>
        public decimal? WaitConfirm { get; set; }
        /// <summary>
        /// Đã duyệt đơn
        /// </summary>
        public decimal? Comfirmed { get; set; }
        /// <summary>
        /// Đã mua hàng
        /// </summary>
        public decimal? PurchaseOrder { get; set; }
        /// <summary>
        /// Đã về kho TQ
        /// </summary>
        public decimal? InChinaWarehoue { get; set; }
        /// <summary>
        /// Đã về kho VN
        /// </summary>
        public decimal? InVietnamWarehoue { get; set; }
        /// <summary>
        /// Chờ thanh toán
        /// </summary>
        public decimal? WaitPayment { get; set; }
        /// <summary>
        /// Khách đã thanh toán
        /// </summary>
        public decimal? Paid { get; set; }
        /// <summary>
        /// Đã hoàn thành
        /// </summary>
        public decimal? Completed { get; set; }
        /// <summary>
        /// Đã khiếu nại
        /// </summary>
        public decimal? Complained { get; set; }


    }

    public class TransportationsInfor
    {
        /// <summary>
        /// Tổng số đơn hàng 
        /// </summary>
        public int TotalOrders { get; set; }
        /// <summary>
        /// Đơn hàng mới
        /// </summary>
        public int TotalNewOrders { get; set; }
        /// <summary>
        /// Đơn hàng đã duyệt
        /// </summary>
        public int ToTalConfimed { get; set; }
        /// <summary>
        /// Đơn hàng đã có tại kho TQ
        /// </summary>
        public int TotalInChina { get; set; }
        /// <summary>
        /// Đơn hàng đã có tại kho VN
        /// </summary>
        public int TotalInVietnam { get; set; }
        /// <summary>
        /// Đơn hàng đã thanh toán
        /// </summary>
        public int TotalPaid { get; set; }
        /// <summary>
        /// Đơn hàng đã nhận
        /// </summary>
        public int TotalCompleted { get; set; }
        /// <summary>
        /// Đơn hàng đã hủy
        /// </summary>
        public int TotalCancled { get; set; }
    }
    public class TransportationsAmount
    {
        /// <summary>
        /// Tổng tiền hàng chưa giao
        /// </summary>
        public decimal AmountNotDelivery { get; set; }
        /// <summary>
        /// Tổng tiền hàng chờ về kho TQ
        /// </summary>
        public decimal AmoutWattingToChina { get; set; }
        /// <summary>
        /// Tổng tiền hàng đã về kho TQ
        /// </summary>
        public decimal AmountInChina { get; set; }
        /// <summary>
        /// Tổng tiền hàng đang ở kho đích
        /// </summary>
        public decimal AmountInVietnam { get; set; }
        /// <summary>
        /// Tổng tiền cần thanh toán để lấy hàng trong kho
        /// </summary>
        public decimal AmountPay { get; set; }
    }
}
