(self.webpackChunk_N_E=self.webpackChunk_N_E||[]).push([[322],{82691:function(e,t,n){"use strict";n.r(t);var r=n(67294),a=n(4445),i=n(34207),l=n(94750),s=n(85893);t.default=function(e){var t=e.handleFilter,n=e.handleExporTExcel,c=(0,r.useRef)(null),u=(0,r.useRef)(null),o=(0,r.useRef)(null),d=(0,r.useRef)(null);return(0,s.jsxs)("div",{className:"xl:grid xl:grid-cols-4 xl:gap-4 w-full",children:[(0,s.jsx)("div",{className:"col-span-1 xl:pb-0 pb-4",children:(0,s.jsx)(i.jw,{placeholder:"T\u1eeb ng\xe0y / \u0111\u1ebfn ng\xe0y",format:"DD/MM/YYYY",handleDate:function(e){u.current=e[0],o.current=e[1]}})}),(0,s.jsx)("div",{className:"col-span-1 xl:pb-0 pb-4",children:(0,s.jsx)(i.zE,{data:l.qP,defaultValue:l.qP[0],placeholder:"Tr\u1ea1ng th\xe1i",label:"L\u1ecdc theo tr\u1ea1ng th\xe1i",handleSearch:function(e){return d.current=e}})}),(0,s.jsxs)("div",{className:"col-span-2 xl:pb-0 flex justify-between items-end",children:[(0,s.jsx)(a.h,{onClick:function(){return t(c.current,u.current,o.current,d.current)},icon:"fas fa-filter",btnClass:"!mr-4",title:"L\u1ecdc",showLoading:!0,toolip:"L\u1ecdc"}),(0,s.jsx)(a.h,{onClick:function(){return n()},btnClass:"",icon:"fas fa-file-export",title:"Xu\u1ea5t",showLoading:!0,toolip:"Xu\u1ea5t th\u1ed1ng k\xea",green:!0})]})]})}},58128:function(e,t,n){"use strict";n.r(t);n(77785);var r=n(59361),a=(n(67294),n(27733)),i=n(94750),l=n(21986),s=n(85893);t.default=function(e){var t=e.data,n=e.handlePagination,c=e.pagination,u=e.loading,o=[{dataIndex:"Id",title:"ID",align:"center",sorter:!0},{dataIndex:"TotalPrice",title:"T\u1ed5ng ti\u1ec1n (\xa5)",align:"center",render:function(e){return l.Jy.getVND(e," ")},responsive:["sm"]},{dataIndex:"TotalPriceVND",title:"T\u1ed5ng ti\u1ec1n (VN\u0110)",align:"center",render:function(e){return l.Jy.getVND(e," ")},responsive:["md"]},{dataIndex:"Currency",title:"T\u1ef7 gi\xe1",align:"center",responsive:["md"]},{dataIndex:"Created",title:"Ng\xe0y t\u1ea1o",align:"center",render:function(e){return l.Jy.getShortVNDate(e)},responsive:["xl"]},{dataIndex:"Status",title:"Tr\u1ea1ng th\xe1i",align:"center",sorter:!0,render:function(e,t){var n="green";return 1===e?n="orange":2===e?n="blue":3===e&&(n="red"),(0,s.jsx)(r.default,{color:n,children:null===t||void 0===t?void 0:t.StatusName})},responsive:["xl"]}],d={expandedRowRender:function(e){return(0,s.jsxs)("ul",{className:"px-2 text-xs",children:[(0,s.jsxs)("li",{className:"sm:hidden justify-between flex py-2",children:[(0,s.jsx)("span",{className:"font-medium mr-4",children:"T\u1ed5ng ti\u1ec1n (t\u1ec7):"}),l.Jy.getVND(e.TotalPrice)]}),(0,s.jsxs)("li",{className:"md:hidden justify-between flex py-2",children:[(0,s.jsx)("span",{className:"font-medium mr-4",children:"T\u1ed5ng ti\u1ec1n (vn\u0111):"}),l.Jy.getVND(e.TotalPriceVND)]}),(0,s.jsxs)("li",{className:"md:hidden justify-between flex py-2",children:[(0,s.jsx)("span",{className:"font-medium mr-4",children:"T\u1ef7 gi\xe1:"}),e.Currency]}),(0,s.jsxs)("li",{className:"lg:hidden justify-between flex py-2",children:[(0,s.jsx)("span",{className:"font-medium mr-4",children:"Ch\u01b0a ho\xe0n thi\u1ec7n:"}),e.isComplete?(0,s.jsx)("i",{className:"fad fa-check text-2xl text-green"}):(0,s.jsx)("i",{className:"far fa-times text-2xl text-red"})]}),(0,s.jsxs)("li",{className:"xl:hidden justify-between flex py-2",children:[(0,s.jsx)("span",{className:"font-medium mr-4",children:"Ng\xe0y t\u1ea1o:"}),l.Jy.getVNDate(e.Created)]}),(0,s.jsxs)("li",{className:"xl:hidden justify-between flex py-2",children:[(0,s.jsx)("span",{className:"font-medium mr-4",children:"Tr\u1ea1ng th\xe1i:"}),(0,s.jsx)(r.default,{color:i.qP[e.Status].color,children:i.qP[e.Status].name})]})]})}};return(0,s.jsx)(a.wQF,{loading:u,columns:o,data:t,bordered:!0,pagination:c,onChange:n,expandable:d})}},81167:function(e,t,n){"use strict";n.r(t);var r=n(30266),a=n(92809),i=n(809),l=n.n(i),s=n(11163),c=n(67294),u=n(88767),o=n(44862),d=n(27733),f=n(94750),x=n(21986),p=n(82691),h=n(58128),g=n(85893);function m(e,t){var n=Object.keys(e);if(Object.getOwnPropertySymbols){var r=Object.getOwnPropertySymbols(e);t&&(r=r.filter((function(t){return Object.getOwnPropertyDescriptor(e,t).enumerable}))),n.push.apply(n,r)}return n}function j(e){for(var t=1;t<arguments.length;t++){var n=null!=arguments[t]?arguments[t]:{};t%2?m(Object(n),!0).forEach((function(t){(0,a.Z)(e,t,n[t])})):Object.getOwnPropertyDescriptors?Object.defineProperties(e,Object.getOwnPropertyDescriptors(n)):m(Object(n)).forEach((function(t){Object.defineProperty(e,t,Object.getOwnPropertyDescriptor(n,t))}))}return e}t.default=function(){var e=(0,s.useRouter)().query,t=(0,c.useState)(f.G2),n=t[0],a=t[1],i=(0,c.useState)(f.Nc),m=i[0],y=i[1],v=(0,c.useState)(null),N=v[0],b=v[1],w=(0,c.useState)(null),D=w[0],P=w[1],S=(0,c.useState)(null),O=S[0],T=S[1],C=(0,c.useState)(0),E=C[0],k=C[1],I=(0,u.useQuery)(["requestPaymentData",{PageCurrent:n.current,PageSize:n.pageSize,FromDate:D,ToDate:O,Status:E,OrderBy:x.Jy.getCurrentSorter(m),SearchContent:N,uid:+(null===e||void 0===e?void 0:e.id)}],(function(){return o.uD.getList({PageIndex:n.current,PageSize:n.pageSize,Status:E>0?E:null,OrderBy:x.Jy.getCurrentSorter(m),SearchContent:N,FromDate:D,ToDate:O,UID:+(null===e||void 0===e?void 0:e.id)}).then((function(e){return e.Data}))}),{keepPreviousData:!0,onSuccess:function(e){return a(j(j({},n),{},{total:null===e||void 0===e?void 0:e.TotalItem}))},onError:d.Amu.error,enabled:!(null===e||void 0===e||!e.id)}),_=I.isFetching,V=I.data,J=(I.isLoading,function(){var e=(0,r.Z)(l().mark((function e(){var t;return l().wrap((function(e){for(;;)switch(e.prev=e.next){case 0:return e.prev=0,e.next=3,o.uD.exportExcel({});case 3:t=e.sent,s.default.push("".concat(t.Data)),e.next=10;break;case 7:e.prev=7,e.t0=e.catch(0),d.Amu.error(e.t0);case 10:case"end":return e.stop()}}),e,null,[[0,7]])})));return function(){return e.apply(this,arguments)}}());return(0,g.jsxs)(g.Fragment,{children:[(0,g.jsx)("div",{className:"my-4",children:(0,g.jsx)(p.default,{handleFilter:function(e,t,n,r){b(e),P(t),T(n),k(r)},handleExporTExcel:J})}),(0,g.jsx)(h.default,{loading:_,data:null===V||void 0===V?void 0:V.Items,pagination:n,handlePagination:function(e,t,n){a(e),y(n)}})]})}},15254:function(e,t,n){(window.__NEXT_P=window.__NEXT_P||[]).push(["/manager/client/order-list/payHelp",function(){return n(81167)}])}},function(e){e.O(0,[675,296,3662,7570,3997,335,9774,2888,179],(function(){return t=15254,e(e.s=t);var t}));var t=e.O();_N_E=t}]);