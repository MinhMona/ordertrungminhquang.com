(self.webpackChunk_N_E=self.webpackChunk_N_E||[]).push([[9112],{44419:function(a,b,c){(window.__NEXT_P=window.__NEXT_P||[]).push(["/manager/deposit/deposit-list/detail",function(){return c(50891)}])},50891:function(a,b,c){"use strict";c.r(b);var d=c(28520),e=c.n(d),f=c(85893),g=c(11382),h=c(11163),i=c(67294),j=c(88767),k=c(43194),l=c(61980),m=c(87023),n=c(90198),o=c(13431);function p(a,b,c,d,e,f,g){try{var h=a[f](g),i=h.value}catch(j){c(j);return}h.done?b(i):Promise.resolve(i).then(d,e)}var q=function(a){var b=a.connection,c=(0,o.CG)(o.dy).user;if(!c)return null;var d=(0,h.useRouter)().query,m=(0,i.useState)(!1),q=m[0],r=m[1],s=(0,j.useQueryClient)();(0,i.useEffect)(function(){var a=null;return b&&b.on("change",function(a){return function(){var b=this,c=arguments;return new Promise(function(d,e){var f=a.apply(b,c);function g(a){p(f,d,e,g,h,"next",a)}function h(a){p(f,d,e,g,h,"throw",a)}g(void 0)})}}(e().mark(function b(c,f){var g;return e().wrap(function(b){for(;;)switch(b.prev=b.next){case 0:f.length&&(g=f.find(function(a){return a.Id=== +(null==d?void 0:d.id)}))&&(r(!0),s.setQueryData(["depositList",+(null==d?void 0:d.id)],{Data:g}),a=setTimeout(function(){return r(!1)},2000));case 1:case"end":return b.stop()}},b)}))),function(){return clearTimeout(a)}},[b]);var t=(0,j.useQuery)(["depositList",+(null==d?void 0:d.id)],function(){return k.V8.getByID(+(null==d?void 0:d.id))},{onError:l.Amu.error,refetchOnWindowFocus:!0,retry:!1,enabled:!!(null==d?void 0:d.id)}),u=t.data,v=t.isError,w=t.isLoading,x=(0,n.N)({shippingTypeToWarehouseEnabled:!0}).shippingTypeToWarehouse;return v?(0,f.jsx)(l.TXS,{}):(0,f.jsx)(g.Z,{spinning:q,children:(0,f.jsx)("div",{className:" p-4 mb-6",children:(0,f.jsx)(l.srA,{defaultValues:null==u?void 0:u.Data,shippingTypeToWarehouseCatalogue:x,loading:w,RoleID:null==c?void 0:c.UserGroupId})})})};q.breadcrumb=m.m.deposit.depositList.detail,q.Layout=l.Ar2,b.default=q}},function(a){a.O(0,[675,296,3662,7570,8022,8947,9774,2888,179],function(){return a(a.s=44419)}),_N_E=a.O()}])