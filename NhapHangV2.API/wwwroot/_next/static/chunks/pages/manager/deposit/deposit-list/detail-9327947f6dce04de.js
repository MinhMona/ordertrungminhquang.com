(self.webpackChunk_N_E=self.webpackChunk_N_E||[]).push([[9112],{43082:function(a,b,c){"use strict";c.r(b);var d=c(9405);c.n(d);var e=c(89552),f=c(30266),g=c(809),h=c.n(g),i=c(11163),j=c(67294),k=c(88767),l=c(44862),m=c(27733),n=c(57411),o=c(82381),p=c(66727),q=c(85893),r=function(a){var b=a.connection,c=(0,p.CG)(p.dy).user;if(!c)return null;var d=(0,i.useRouter)().query,g=(0,j.useState)(!1),n=g[0],r=g[1],s=(0,k.useQueryClient)();(0,j.useEffect)(function(){var a=null;return b&&b.on("change",function(){var b=(0,f.Z)(h().mark(function b(c,e){var f;return h().wrap(function(b){for(;;)switch(b.prev=b.next){case 0:e.length&&(f=e.find(function(a){return a.Id=== +(null==d?void 0:d.id)}))&&(r(!0),s.setQueryData(["depositList",+(null==d?void 0:d.id)],{Data:f}),a=setTimeout(function(){return r(!1)},2000));case 1:case"end":return b.stop()}},b)}));return function(a,c){return b.apply(this,arguments)}}()),function(){return clearTimeout(a)}},[b]);var t=(0,k.useQuery)(["depositList",+(null==d?void 0:d.id)],function(){return l.V8.getByID(+(null==d?void 0:d.id))},{onError:m.Amu.error,refetchOnWindowFocus:!0,retry:!1,enabled:!!(null!=d&&d.id)}),u=t.data,v=t.isError,w=t.isLoading,x=(0,o.N)({shippingTypeToWarehouseEnabled:!0}),y=x.shippingTypeToWarehouse;return v?(0,q.jsx)(m.TXS,{}):(0,q.jsx)(e.default,{spinning:n,children:(0,q.jsx)("div",{className:" p-4 mb-6",children:(0,q.jsx)(m.srA,{defaultValues:null==u?void 0:u.Data,shippingTypeToWarehouseCatalogue:y,loading:w,RoleID:null==c?void 0:c.UserGroupId})})})};r.breadcrumb=n.m.deposit.depositList.detail,r.Layout=m.Ar2,b.default=r},44419:function(a,b,c){(window.__NEXT_P=window.__NEXT_P||[]).push(["/manager/deposit/deposit-list/detail",function(){return c(43082)}])}},function(a){a.O(0,[675,296,3662,7570,3997,335,9774,2888,179],function(){return a(a.s=44419)}),_N_E=a.O()}])