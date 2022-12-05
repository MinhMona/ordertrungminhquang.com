using Microsoft.EntityFrameworkCore;
using NhapHangV2.Entities;
using NhapHangV2.Entities.Auth;
using NhapHangV2.Entities.Catalogue;
using NhapHangV2.Entities.Configuration;
using NhapHangV2.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapHangV2.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permissions>().HasData(
                    new Permissions() { Id = 1, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "AddNew", Name = "Thêm mới", Description = "" },
                    new Permissions() { Id = 2, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "Update", Name = "Cập nhật", Description = "" },
                    new Permissions() { Id = 3, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "Delete", Name = "Xóa", Description = "" },
                    new Permissions() { Id = 4, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "View", Name = "Xem", Description = "" },
                    new Permissions() { Id = 5, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "Download", Name = "Download", Description = "" },
                    new Permissions() { Id = 6, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "Upload", Name = "Upload", Description = "" },
                    new Permissions() { Id = 7, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "Import", Name = "Import", Description = "" },
                    new Permissions() { Id = 8, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "Export", Name = "Export", Description = "" },
                    new Permissions() { Id = 9, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "ViewAll", Name = "Xem tất cả", Description = "" }
                );

            modelBuilder.Entity<UserGroups>().HasData(
                    new UserGroups() { Id = 1, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "ADMIN", Name = "Admin", Description = "Admin" },
                    new UserGroups() { Id = 2, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "USER", Name = "User", Description = "User" },
                    new UserGroups() { Id = 3, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "MANAGER", Name = "Manager", Description = "Quản lý" },
                    new UserGroups() { Id = 4, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true,
                        Code = "ORDERER", Name = "Orderer", Description = "Đặt hàng" },
                    new UserGroups() { Id = 5, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true,
                        Code = "CHINAWAREHOUSEMANAGER", Name = "China Warehouse Manager", Description = "Kho TQ" },
                    new UserGroups() { Id = 6, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true,
                        Code = "VIETNAMWAREHOUSEMANAGER", Name = "Viet Nam Warehouse Manager", Description = "Kho VN" },
                    new UserGroups() { Id = 7, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true,
                        Code = "SALER", Name = "Saler", Description = "Saler" },
                    new UserGroups() { Id = 8, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true,
                        Code = "ACCOUNTANT", Name = "Accountant", Description = "Kế toán" },
                    new UserGroups() { Id = 9, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true,
                        Code = "STOREKEEPERS", Name = "Storekeepers", Description = "Thủ kho" }
                );

            modelBuilder.Entity<Warehouse>().HasData(
                    new Warehouse() { Id = 1, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "HO-CHI-MINH", Name = "Hồ Chí Minh", Description = "", ExpectedDate = 0, Latitude = "10.7769683", Longitude = "106.6526192" },
                    new Warehouse() { Id = 2, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "HA-NOI", Name = "Hà Nội", Description = "", ExpectedDate = 0, Latitude = "21.0200547", Longitude = "105.8274364" }
                );

            modelBuilder.Entity<WarehouseFrom>().HasData(
                    new WarehouseFrom() { Id = 1, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "DONG-HUNG", Name = "Đông Hưng", Description = "", Latitude = "22.1153264", Longitude = "106.6974036" },
                    new WarehouseFrom() { Id = 2, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "QUANG-CHAU", Name = "Quảng Châu", Description = "", Latitude = "22.1153264", Longitude = "106.6974036" },
                    new WarehouseFrom() { Id = 3, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "BANG-TUONG", Name = "Bằng Tường", Description = "", Latitude = "22.1153264", Longitude = "106.6974036" }
                );

            modelBuilder.Entity<ShippingTypeToWareHouse>().HasData(
                    new ShippingTypeToWareHouse() { Id = 1, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "DI-THUONG", Name = "Đi thường", Description = "" },
                    new ShippingTypeToWareHouse() { Id = 2, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "DI-NHANH", Name = "Đi nhanh", Description = "" }
                );

            modelBuilder.Entity<ShippingTypeVN>().HasData(
                    new ShippingTypeVN() { Id = 1, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "NHANH-VIETTEL-POST", Name = "Chuyển phát nhanh Viettel Post(không chuyển mỹ phẩm, chất lỏng, đồ điện tử)" },
                    new ShippingTypeVN() { Id = 2, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "CHAM-VIETTEL-POST", Name = "Chuyển phát chậm Viettel Post" },
                    new ShippingTypeVN() { Id = 3, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "V60-VIETTEL-POST", Name = "Chuyển phát V60 Viettel Post(trên 5kg )" },
                    new ShippingTypeVN() { Id = 4, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "LAY-HANG-HN", Name = "Lấy tại văn phòng Hà Nội(kho xếp hàng ra trước )" },
                    new ShippingTypeVN() { Id = 5, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "GUI-HANG-HN", Name = "Gửi ship nội thành(áp dụng với khách tại Hà Nội )" },
                    new ShippingTypeVN() { Id = 6, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "KHAC", Name = "Các hình thức vận chuyển khác khách ghi chú cụ thể bên dưới" }
                );

            modelBuilder.Entity<UserLevel>().HasData(
                    new UserLevel() { Id = 1, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Name = "VIP 0", FeeBuyPro = 0, FeeWeight = 0, LessDeposit = 70, Money = 0, MoneyTo = 100000000 },
                    new UserLevel() { Id = 2, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Name = "VIP 1", FeeBuyPro = 5, FeeWeight = 0, LessDeposit = 70, Money = 100000001, MoneyTo = 300000000 },                    
                    new UserLevel() { Id = 3, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Name = "VIP 2", FeeBuyPro = 10, FeeWeight = 0, LessDeposit = 70, Money = 300000001, MoneyTo = 800000000 },
                    new UserLevel() { Id = 4, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Name = "VIP 3", FeeBuyPro = 15, FeeWeight = 0, LessDeposit = 70, Money = 800000001, MoneyTo = 1500000000 },
                    new UserLevel() { Id = 5, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Name = "VIP 4", FeeBuyPro = 20, FeeWeight = 2, LessDeposit = 65, Money = 1500000001, MoneyTo = 2500000000 },
                    new UserLevel() { Id = 6, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Name = "VIP 5", FeeBuyPro = 25, FeeWeight = 4, LessDeposit = 60, Money = 2500000001, MoneyTo = 5000000000 },
                    new UserLevel() { Id = 7, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Name = "VIP 6", FeeBuyPro = 30, FeeWeight = 6, LessDeposit = 55, Money = 5000000001, MoneyTo = 10000000000 },
                    new UserLevel() { Id = 8, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Name = "VIP 7", FeeBuyPro = 35, FeeWeight = 8, LessDeposit = 50, Money = 10000000001, MoneyTo = 20000000000 },
                    new UserLevel() { Id = 9, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Name = "VIP 8", FeeBuyPro = 40, FeeWeight = 10, LessDeposit = 50, Money = 20000000001, MoneyTo = 990000000000 }
                );

            modelBuilder.Entity<FeeBuyPro>().HasData(
                    new FeeBuyPro() { Id = 1, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        PriceFrom = 0, PriceTo = 1000000, FeePercent = 3 },
                    new FeeBuyPro() { Id = 2, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        PriceFrom = 1000001, PriceTo = 30000000, FeePercent = 2.5M },
                    new FeeBuyPro() { Id = 3, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        PriceFrom = 30000001, PriceTo = 100000000, FeePercent = 2 },
                    new FeeBuyPro() { Id = 4, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        PriceFrom = 100000001, PriceTo = 200000000, FeePercent = 1.5M },
                    new FeeBuyPro() { Id = 5, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        PriceFrom = 200000001, PriceTo = 9999999999, FeePercent = 1 }
                );

            modelBuilder.Entity<FeeCheckProduct>().HasData(
                    new FeeCheckProduct() { Id = 1, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        AmountFrom = 0, AmountTo = 2, Fee = 5000, Type = 1 },
                    new FeeCheckProduct() { Id = 2, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        AmountFrom = 0, AmountTo = 2, Fee = 1500, Type = 2 },
                    new FeeCheckProduct() { Id = 3, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        AmountFrom = 3, AmountTo = 10, Fee = 3500, Type = 1 },
                    new FeeCheckProduct() { Id = 4, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        AmountFrom = 3, AmountTo = 10, Fee = 1000, Type = 2 },
                    new FeeCheckProduct() { Id = 5, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        AmountFrom = 11, AmountTo = 100, Fee = 2000, Type = 1 },
                    new FeeCheckProduct() { Id = 6, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        AmountFrom = 11, AmountTo = 100, Fee = 700, Type = 2 },
                    new FeeCheckProduct() { Id = 7, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        AmountFrom = 101, AmountTo = 500, Fee = 1500, Type = 1 },
                    new FeeCheckProduct() { Id = 8, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        AmountFrom = 101, AmountTo = 500, Fee = 700, Type = 2 },
                    new FeeCheckProduct() { Id = 9, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        AmountFrom = 501, AmountTo = 99999, Fee = 1000, Type = 1 },
                    new FeeCheckProduct() { Id = 10, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        AmountFrom = 501, AmountTo = 99999, Fee = 700, Type = 2 }
                );

            modelBuilder.Entity<FeePackaged>().HasData(
                    new FeePackaged() { Id = 1, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        InitialKg = 20, FirstPrice = 2, NextPrice = 1 }
                );

            modelBuilder.Entity<InWareHousePrice>().HasData(
                    new InWareHousePrice() { Id = 1, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        WeightFrom = 0, WeightTo = 20, MaxDay = 7, PricePay = 0 },
                    new InWareHousePrice() { Id = 2, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        WeightFrom = 21, WeightTo = 999999, MaxDay = 5, PricePay = 0 }
                );

            modelBuilder.Entity<PageSEO>().HasData(
                    new PageSEO() { Id = 1, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "trang-chu", Name = "Trang chủ", Description = "Trang chủ", OGUrl = "", OGImage = "", OGTitle = "Trang chủ", OGDescription = "Trang chủ", MetaTitle = "Trang chủ", MetaDescription = "Trang chủ", MetaKeyword = "nhap hang van chuyen da quoc gia, nhập hàng Trung Quốc" },
                    new PageSEO() { Id = 2, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "cong-cu-dat-hang", Name = "Công cụ đặt hàng", Description = "Công cụ đặt hàng", OGUrl = "", OGImage = "", OGTitle = "Công cụ đặt hàng", },
                    new PageSEO() { Id = 3, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "dat-hang-nhanh", Name = "Đặt hàng nhanh", Description = "Đặt hàng nhanh", OGUrl = "", OGImage = "", OGTitle = "Đặt hàng nhanh", },
                    new PageSEO() { Id = 4, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "dang-nhap", Name = "Đăng nhập", Description = "Đăng nhập", OGUrl = "", OGImage = "", OGTitle = "Đăng nhập",},
                    new PageSEO() { Id = 5, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "dang-ky", Name = "Đăng ký", Description = "Đăng ký", OGUrl = "", OGImage = "", OGTitle = "Đăng ký", }
                );

            modelBuilder.Entity<SMSEmailTemplates>().HasData(
                    new SMSEmailTemplates() { Id = 1, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "XNOTP", Name = "Xác nhận OTP", Description = "Xác nhận OTP", IsSMS = true, Subject = "Xác thực OTP", Body = "{0} là mã đặt lại mật khẩu của bạn" },
                    new SMSEmailTemplates() { Id = 2, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        Code = "XNOTP", Name = "Xác nhận OTP", Description = "Xác nhận OTP", IsSMS = false, Subject = "OTP Xác thực", Body = "<p>Mã OTP của bạn là: {0}. Thời hạn OTP hiệu lực trong 1 phút.</p>" }
                );

            modelBuilder.Entity<EmailConfigurations>().HasData(
                    new EmailConfigurations() { Id = 1, Created = DateTime.Now, CreatedBy = "admin", Updated = DateTime.Now, UpdatedBy = "admin", Deleted = false, Active = true, 
                        SmtpServer = "smtp.gmail.com", Port = 587, EnableSsl = true, ConnectType = 1, DisplayName = "No-reply", UserName = "qa-no-reply@ggg.com.vn", Email = "qa-no-reply@ggg.com.vn", Password = StringCipher.Encrypt("1q2w3e", StringCipher.PassPhrase), ItemSendCount = 100, TimeSend = 1 }
                );
        }
    }
}
