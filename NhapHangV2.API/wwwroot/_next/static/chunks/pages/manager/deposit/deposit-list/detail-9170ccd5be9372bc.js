(self.webpackChunk_N_E=self.webpackChunk_N_E||[]).push([[9112],{43082:function(e,n,i){"use strict";i.r(n);i(9405);var r=i(89552),t=i(30266),u=i(809),o=i.n(u),s=i(11163),a=i(67294),d=i(88767),l=i(44862),c=i(27733),p=i(57411),f=i(82381),v=i(66727),h=i(85893),y=function(e){var n=e.connection,i=(0,v.CG)(v.dy).user;if(!i)return null;var u=(0,s.useRouter)().query,p=(0,a.useState)(!1),y=p[0],_=p[1],g=(0,d.useQueryClient)();(0,a.useEffect)((function(){var e=null;return n&&n.on("change",function(){var n=(0,t.Z)(o().mark((function n(i,r){var t;return o().wrap((function(n){for(;;)switch(n.prev=n.next){case 0:r.length&&(t=r.find((function(e){return e.Id===+(null===u||void 0===u?void 0:u.id)})))&&(_(!0),g.setQueryData(["depositList",+(null===u||void 0===u?void 0:u.id)],{Data:t}),e=setTimeout((function(){return _(!1)}),2e3));case 1:case"end":return n.stop()}}),n)})));return function(e,i){return n.apply(this,arguments)}}()),function(){return clearTimeout(e)}}),[n]);var T=(0,d.useQuery)(["depositList",+(null===u||void 0===u?void 0:u.id)],(function(){return l.V8.getByID(+(null===u||void 0===u?void 0:u.id))}),{onError:c.Amu.error,refetchOnWindowFocus:!0,retry:!1,enabled:!(null===u||void 0===u||!u.id)}),m=T.data,w=T.isError,E=T.isLoading,b=(0,f.N)({shippingTypeToWarehouseEnabled:!0}).shippingTypeToWarehouse;return w?(0,h.jsx)(c.TXS,{}):(0,h.jsx)(r.default,{spinning:y,children:(0,h.jsx)("div",{className:" p-4 mb-6",children:(0,h.jsx)(c.srA,{defaultValues:null===m||void 0===m?void 0:m.Data,shippingTypeToWarehouseCatalogue:b,loading:E,RoleID:null===i||void 0===i?void 0:i.UserGroupId})})})};y.breadcrumb=p.m.deposit.depositList.detail,y.Layout=c.Ar2,n.default=y},44419:function(e,n,i){(window.__NEXT_P=window.__NEXT_P||[]).push(["/manager/deposit/deposit-list/detail",function(){return i(43082)}])}},function(e){e.O(0,[675,296,3662,7570,3997,335,9774,2888,179],(function(){return n=44419,e(e.s=n);var n}));var n=e.O();_N_E=n}]);