(self.webpackChunk_N_E=self.webpackChunk_N_E||[]).push([[643],{40628:function(a,b,c){"use strict";var d=c(30266),e=c(809),f=c.n(e),g=c(30381),h=c.n(g),i=c(67294),j=c(27733),k=c(85893);b.Z=function(a){var b=a.handleFilter,c=a.isFetching,e=(0,i.useRef)(null),g=(0,i.useRef)(null);function l(){return m.apply(this,arguments)}function m(){return(m=(0,d.Z)(f().mark(function a(){var c,d,i=arguments;return f().wrap(function(a){for(;;)switch(a.prev=a.next){case 0:if(c=i.length>0&& void 0!==i[0]&&i[0],b){a.next=3;break}return a.abrupt("return");case 3:if(c){a.next=6;break}return b(e.current,g.current),a.abrupt("return");case 6:b(d=h()().format("YYYY-MM-DD"),d);case 8:case"end":return a.stop()}},a)}))).apply(this,arguments)}return(0,k.jsxs)("div",{className:"xl:flex w-fit items-end",children:[(0,k.jsx)("div",{className:"mr-4 mb-4 xl:mb-0 w-[400px]",children:(0,k.jsx)(j.jwb,{disabled:c,format:"DD/MM/YYYY",placeholder:"Từ ng\xe0y / đến ng\xe0y",handleDate:function(a){e.current=a[0],g.current=a[1]}})}),(0,k.jsx)("div",{children:(0,k.jsx)(j.hU,{icon:"fas fa-search",title:"T\xecm?",onClick:l,showLoading:!0,toolip:"",disabled:c})}),(0,k.jsx)("div",{className:"ml-4",children:(0,k.jsx)(j.hU,{icon:"far fa-info-square",title:"Lọc h\xf4m nay",onClick:function(){l(!0)},showLoading:!0,toolip:"",disabled:c})})]})}},38724:function(a,b,c){"use strict";var d=c(41664);c(67294);var e=c(18321),f=c(36417),g=c(21986),h=c(85893);b.Z=function(a){var b=a.data,c=a.pagination,i=a.handlePagination,j=a.loading;return a.isFetching,(0,h.jsx)(f.w,{loading:j,columns:[{dataIndex:"Id",title:"STT",width:50,render:function(a,b,c){return c++}},{dataIndex:"Created",title:"Ng\xe0y",width:130,render:function(a){return g.Jy.getVNDate(a)},responsive:["sm"]},{dataIndex:"NotificationContent",title:"Nội dung",responsive:["lg"],width:200},{dataIndex:"TotalPriceReceive",title:"Trạng th\xe1i",responsive:["xl"],width:120,render:function(a,b){return(0,h.jsx)("span",{style:{color:b.IsRead?"black":"red"},children:b.IsRead?"Đ\xe3 xem":"Chưa xem"})}},{dataIndex:"GoToDetail",title:"Xem chi tiết",align:"center",width:90,render:function(a,b){return(0,h.jsx)(d.default,{href:null==b?void 0:b.Url,children:(0,h.jsx)("a",{style:{opacity:b.Url?"1":"0.3",pointerEvents:b.Url?"all":"none",cursor:b.Url?"pointer":"none"},children:(0,h.jsx)(e.K,{icon:"far fa-info-square",title:"Xem chi tiết"})})})}}],data:b,bordered:!0,pagination:(null==b?void 0:b.length)===0?null:c,onChange:i,expandable:{expandedRowRender:function(a){return(0,h.jsxs)("ul",{className:"px-2 text-xs",children:[(0,h.jsxs)("li",{className:"sm:hidden justify-between flex py-2",children:[(0,h.jsx)("span",{className:"font-medium mr-4",children:"Ng\xe0y:"}),(0,h.jsx)("div",{children:g.Jy.getShortVNDate(null==a?void 0:a.Created)})]}),(0,h.jsxs)("li",{className:"md:hidden justify-between flex py-2",children:[(0,h.jsx)("span",{className:"font-medium mr-4",children:"Nội dung:"}),(0,h.jsx)("div",{children:null==a?void 0:a.NotificationContent})]}),(0,h.jsxs)("li",{className:"xl:hidden justify-between flex py-2",children:[(0,h.jsx)("span",{className:"font-medium mr-4",children:"Trạng th\xe1i:"}),(0,h.jsx)("div",{children:null==a?void 0:a.TotalPriceReceive})]})]})}},scroll:{y:700}})}},93077:function(a,b,c){"use strict";c.d(b,{B:function(){return d},W:function(){return e}});var d={dasboard:"Trang điều khiển",settings:{system:"Cấu h\xecnh hệ thống",feeTQVN:"Cấu h\xecnh vận chuyển TQVN",feeBuy:"Cấu h\xecnh ph\xed dịch vụ mua h\xe0ng",feePayFor:"Cấu h\xecnh ph\xed thanh to\xe1n hộ",feeUser:"Cấu h\xecnh ph\xed người d\xf9ng",listBank:"Danh s\xe1ch ng\xe2n h\xe0ng",notification:"Cấu h\xecnh th\xf4ng b\xe1o",goodsChecking:"Cấu h\xecnh ph\xed kiểm đếm",wareHouse:"Cấu h\xecnh kho TQ - VN"},staff:{employeeManager:"Quản l\xfd nh\xe2n vi\xean",decentralization:"Quản l\xfd ph\xe2n quyền",infoAccount:"Th\xf4ng tin t\xe0i khoản",commissionManager:"Quản l\xfd hoa hồng"},listCustomer:"Danh s\xe1ch kh\xe1ch h\xe0ng",createNewClient:"Th\xeam mới kh\xe1ch h\xe0ng",oder:{orderMain:"Danh s\xe1ch đơn h\xe0ng",oderBuyFor:"Đơn h\xe0ng mua hộ",oderBuyForOther:"Đơn h\xe0ng mua hộ kh\xe1c",payFor:"Đơn h\xe0ng thanh to\xe1n hộ",detail:" Chi tiết đơn h\xe0ng",payOder:"Thanh to\xe1n đơn h\xe0ng",createdOder:"Tạo đơn h\xe0ng kh\xe1c",detailProduct:"Chi tiết sản phẩm"},handleComplaint:"Xử l\xfd khiếu nại",deposit:{listDeposit:"Danh s\xe1ch vận chuyển hộ",statisticalFeeDeposit:"Thống k\xea cước vận chuyển hộ",exportDepositRequest:"Xuất kho k\xfd gửi đ\xe3 y\xeau cầu",exportDeposit:"Xuất kho kiện chưa y\xeau cầu",detailRequest:"Chi tiết y\xeau cầu"},checkWarehouseTQ:"Kiểm h\xe0ng kho TQ",checkWarehouseVN:"Kiểm h\xe0ng kho VN",importWarehouseTQ:"Nhập kho TQ",assignPro:"G\xe1n kiện cho kh\xe1ch","export":"Xuất kho",parcelManagement:{packageManagement:"Quản l\xfd bao h\xe0ng",billCodeManager:"Quản l\xfd m\xe3 vận đơn",lostCase:"Danh s\xe1ch kiện thất lạc",floatingCase:"Danh s\xe1ch kiện tr\xf4i nổi",detailPackageManagement:"Quản l\xfd bao h\xe0ng chi tiết"},moneyManagement:{personalRecharge:"quản l\xfd nạp tiền c\xe1 nh\xe2n",historyRechargeVN:"Lịch sử nạp tiền",historyWithdrawVN:"Lịch sử r\xfat tiền",historyRechargeTQ:"Lịch sử nạp tệ",historyWithdrawTQ:"Lịch sử r\xfat tệ",historyTransaction:"Lịch sử giao dịch",payExport:"Thanh to\xe1n xuất kho",detailPayExport:"Chi tiết thanh to\xe1n xuất kho"},statistical:{printPurchaseVoucher:"In phiếu mua hộ",turnover:"Thống k\xea doanh thu",depositMoney:"Thống k\xea tiền nạp",surplus:"Thống k\xea số dư",transaction:"Thống k\xea giao dịch",other:"Thống k\xea đơn h\xe0ng",realMoney:"Thống k\xea tiền mua h\xe0ng",depositRevenue:"Thống k\xea k\xfd gửi",salesRevenue:"Thống k\xea sale",orderRevenue:"Thống k\xea đặt h\xe0ng",profitBuyFor:"Thống k\xea lợi nhuận mua hộ",profitPayFor:"Thống k\xea lợi nhuận mua hộ"},post:{Categories:"Chuy\xean mục b\xe0i viết",listPost:"B\xe0i viết",addCategories:" Th\xeam chuy\xean mục",editCategories:"Chỉnh sửa chuy\xean mục",addPost:"Th\xeam b\xe0i viết",editPost:"Chỉnh sửa b\xe0i viết"},homepageContent:"Cấu h\xecnh trang chủ",detailMenu:"Chi tiết Menu",addMenuChild:"Th\xeam menu con",addMenu:"Th\xeam menu",signIn:"Đăng nhập",register:"Đăng k\xfd",forgotPassword:"Kh\xf4i phục mật khẩu",homePage:"NHAPHANGTRUNGQUOC.MONAMEDIA.NET",notification:"Th\xf4ng b\xe1o"},e={dashboard:"Dashboard",shopping:{shopingBag:"Giỏ h\xe0ng",payment:"Thanh to\xe1n"},buyGroceries:{listOder:"Danh s\xe1ch đơn h\xe0ng",createOderPageTMDT:"Tạo đơn h\xe0ng trang TMĐT Kh\xe1c",listOderTMĐT:"Danh s\xe1ch đơn h\xe0ng"},consignmentShipping:{createOderDeposit:"Tạo đơn h\xe0ng k\xfd gửi",listOderDeposit:"Danh s\xe1ch đơn h\xe0ng k\xfd gửi",statisticalDeposit:"Thống k\xea cước k\xfd gửi"},payFor:{listRequest:"Danh s\xe1ch y\xeau cầu thanh to\xe1n hộ",createRequest:"Tạo y\xeau cầu thanh to\xe1n hộ",detaiPay:"Chi tiết thanh to\xe1n hộ"},financialManagement:{listTransactionVND:" Danh s\xe1ch giao dịch VNĐ",listTransactionTQ:" Danh s\xe1ch giao dịch VNĐ",rechargeVNĐ:"Nạp tiền VNĐ",rechargeTQ:"Nạp tiền TQ",withdrawMoneyVND:"R\xfat tiền VNĐ",withdrawMoneyTQ:"R\xfat tiền TQ"},complain:"Khiếu nại",floating:"Kiện tr\xf4i nổi",createComplain:"Tạo khiếu nại mới",tracking:"Theo d\xf5i vận chuyển",infoUser:"Th\xf4ng tin người d\xf9ng"}},48459:function(a,b,c){"use strict";c.r(b);var d=c(92809),e=c(67294),f=c(88767),g=c(44862),h=c(27733),i=c(40628),j=c(38724),k=c(57411),l=c(93077),m=c(66727),n=c(85893);function o(a,b){var c=Object.keys(a);if(Object.getOwnPropertySymbols){var d=Object.getOwnPropertySymbols(a);b&&(d=d.filter(function(b){return Object.getOwnPropertyDescriptor(a,b).enumerable})),c.push.apply(c,d)}return c}function p(a){for(var b=1;b<arguments.length;b++){var c=null!=arguments[b]?arguments[b]:{};b%2?o(Object(c),!0).forEach(function(b){(0,d.Z)(a,b,c[b])}):Object.getOwnPropertyDescriptors?Object.defineProperties(a,Object.getOwnPropertyDescriptors(c)):o(Object(c)).forEach(function(b){Object.defineProperty(a,b,Object.getOwnPropertyDescriptor(c,b))})}return a}var q=function(a){var b=a.connection,c=(0,e.useState)(k.G2),d=c[0],l=c[1],o=(0,e.useState)(null),q=o[0],r=o[1],s=(0,e.useState)(null),t=s[0],u=s[1],v=(0,m.CG)(function(a){return a.user.current}),w=(0,f.useQuery)(["menuData",{Current:d.current,PageSize:99999,FromDate:q,ToDate:t}],function(){return g.t6.getList({PageIndex:d.current,PageSize:99999,FromDate:q,ToDate:t,OrderBy:"Id desc",UID:null==v?void 0:v.UserId,OfEmployee:!1,IsRead:0}).then(function(a){return null==a?void 0:a.Data})},{retry:!1,keepPreviousData:!0,onSuccess:function(a){var b;l(p(p({},d),{},{total:null==a?void 0:a.TotalItem})),(null==a?void 0:null===(b=a.Items)|| void 0===b?void 0:b.length)<=0&&h.Amu.info("Kh\xf4ng c\xf3 th\xf4ng b\xe1o trong khoảng thời gian n\xe0y!")},onError:h.Amu.error}),x=w.isFetching,y=w.data;return(0,e.useEffect)(function(){b&&b.on("send-notification",function(a){return null==y?void 0:y.Items.unshift(a)})},[b]),(0,n.jsxs)(n.Fragment,{children:[(0,n.jsx)("div",{className:"titlePageUser",children:"Danh s\xe1ch th\xf4ng b\xe1o"}),(0,n.jsxs)("div",{className:"tableBox",children:[(0,n.jsx)("div",{children:(0,n.jsx)(i.Z,{handleFilter:function(a,b){r(a),u(b)},isFetching:x})}),(0,n.jsx)("div",{className:"mt-4",children:(0,n.jsx)(j.Z,{data:null==y?void 0:y.Items,pagination:d,loading:x,handlePagination:function(a){return l(a)}})})]})]})};q.displayName=l.B.notification,q.breadcrumb=k.m.notification,q.Layout=h.rfd,b.default=q},35472:function(a,b,c){(window.__NEXT_P=window.__NEXT_P||[]).push(["/user/notification",function(){return c(48459)}])}},function(a){a.O(0,[675,296,3662,7570,3997,335,9774,2888,179],function(){return a(a.s=35472)}),_N_E=a.O()}])