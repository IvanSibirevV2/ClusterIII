(function(){var e=this,h=function(b,c){var a=b.split("."),d=e;a[0]in d||!d.execScript||d.execScript("var "+a[0]);for(var f;a.length&&(f=a.shift());)a.length||void 0===c?d=d[f]?d[f]:d[f]={}:d[f]=c};var l=function(b,c,a,d){if(4!=a.length)throw Error("The anchors should be an array of length 4.");b={type:"element",spec:{element:b}};c&&(b.alignments=c);c=["top","right","bottom","left"];for(var f=0;f<c.length;++f)a[f]&&(b[c[f]]=a[f]);void 0!==d&&(b.z_index=d);return b};var m=String.prototype.trim?function(b){return b.trim()}:function(b){return b.replace(/^[\s\xa0]+|[\s\xa0]+$/g,"")},r=function(b,c){return b<c?-1:b>c?1:0};var u=function(b,c){var a=t,d;for(d in a)b.call(c,a[d],d,a)};var v;a:{var w=e.navigator;if(w){var x=w.userAgent;if(x){v=x;break a}}v=""};var y=-1!=v.indexOf("Opera")||-1!=v.indexOf("OPR"),z=-1!=v.indexOf("Trident")||-1!=v.indexOf("MSIE"),A=-1!=v.indexOf("Edge"),B=-1!=v.indexOf("Gecko")&&!(-1!=v.toLowerCase().indexOf("webkit")&&-1==v.indexOf("Edge"))&&!(-1!=v.indexOf("Trident")||-1!=v.indexOf("MSIE"))&&-1==v.indexOf("Edge"),C=-1!=v.toLowerCase().indexOf("webkit")&&-1==v.indexOf("Edge"),D=function(){var b=v;if(B)return/rv\:([^\);]+)(\)|;)/.exec(b);if(A)return/Edge\/([\d\.]+)/.exec(b);if(z)return/\b(?:MSIE|rv)[: ]([^\);]+)(\)|;)/.exec(b);
if(C)return/WebKit\/(\S+)/.exec(b)},E=function(){var b=e.document;return b?b.documentMode:void 0},F=function(){if(y&&e.opera){var b;var c=e.opera.version;try{b=c()}catch(a){b=c}return b}b="";(c=D())&&(b=c?c[1]:"");return z&&(c=E(),c>parseFloat(b))?String(c):b}(),G={},H=function(b){if(!G[b]){for(var c=0,a=m(String(F)).split("."),d=m(String(b)).split("."),f=Math.max(a.length,d.length),k=0;0==c&&k<f;k++){var g=a[k]||"",n=d[k]||"",S=RegExp("(\\d*)(\\D*)","g"),T=RegExp("(\\d*)(\\D*)","g");do{var p=S.exec(g)||
["","",""],q=T.exec(n)||["","",""];if(0==p[0].length&&0==q[0].length)break;c=r(0==p[1].length?0:parseInt(p[1],10),0==q[1].length?0:parseInt(q[1],10))||r(0==p[2].length,0==q[2].length)||r(p[2],q[2])}while(0==c)}G[b]=0<=c}},I=e.document,J=I&&z?E()||("CSS1Compat"==I.compatMode?parseInt(F,10):5):void 0;var K;if(!(K=!B&&!z)){var L;if(L=z)L=9<=J;K=L}K||B&&H("1.9.1");z&&H("9");var t={h:"aspectRatio",j:"backgroundColor",l:"color",m:"displayType",v:"padding",C:"paddingTop",A:"paddingLeft",B:"paddingRight",w:"paddingBottom",H:"weight",D:"priority",o:"font_level",i:"autoShrink",s:"horizontalFill",G:"verticalFill",u:"imageEnlargeRatio",F:"truncate"};var M=function(b){this.c=b.font_color_id;this.b=b.background_color_ids;this.a=b.auto_background_color_id;this.g=b.auto_font_color_id;this.f={};u(function(c){null!=b[c]&&(this.f[c]=b[c])},this);this.c&&(this.f.color=this.c);this.b&&(this.f.backgroundColor=this.b)};var N=function(b){return b.google_template_data.adData[0].siriusFlagEnableAutoColor};var O=function(b,c){var a=b.google_template_data.adData[0][c];if(null==a)throw Error("Undefined field of: "+c);return a};var P=/#(.)(.)(.)/,Q=/^#(?:[0-9a-f]{3}){1,2}$/i;var R=/^(?:|#|0x)(?:[a-fA-F\d]{3}){1,2}$/,U=function(b){if(R.test(b))return"#"+b.replace(/^#|0x/,"");throw Error("Invalid HEX color: "+b);};var V=function(b,c){var a=new M(b);return U(O(c,"true"==N(c)&&a.a?a.a:a.b))};
h("getSiriusTextColor",function(b,c){var a;a=new M(b);var d=c.google_template_data.adData[0],f="true"==N(c)?a.g:a.c;if(d[f])a=U(d[f]);else{a=O(c,"true"==N(c)&&a.a?a.a:a.b);a=U(a);if(!Q.test(a))throw Error("'"+a+"' is not a valid hex color");4==a.length&&(a=a.replace(P,"#$1$1$2$2$3$3"));a=a.toLowerCase();a=[parseInt(a.substr(1,2),16),parseInt(a.substr(3,2),16),parseInt(a.substr(5,2),16)];a=200<Math.round((299*a[0]+587*a[1]+114*a[2])/1E3)?"#000000":"#ffffff"}return a});
h("getSiriusBackgroundColor",V);var W={product1MCImage:{type:"background_image",node_id:"adContent"},logoMCImage:{type:"logo",node_id:"logo-image"},text1TFText:{type:"text",font_level:1,component_type:"headline",node_id:"headline",font_color_id:"text1TFTextColor",background_color_ids:"back1MCColor"},text2TFText:{type:"text",font_level:2,component_type:"description",node_id:"description",font_color_id:"text2TFTextColor",background_color_ids:"back1MCColor"},clickTFText:{type:"button",node_id:"button",font_color_id:"clickTFTextColor",
background_color_ids:"back1MCColor",weight:.05},productCover:{type:"shape",node_id:"product-cover",background_color_ids:"back1MCColor"},verticalBorder:{type:"shape",node_id:"border_vertical",background_color_ids:"back2MCColor"},horizontalBorder:{type:"shape",node_id:"border_horizontal",background_color_ids:"back2MCColor"},line:{type:"shape",node_id:"line",background_color_ids:"back1MCColor"},arrow:{type:"shape",node_id:"arrow",background_color_ids:"back1MCColor"}},X={clickTFText:{displayType:"nessieButton"}},
Y={elements:W,font_scale_strategy:"mega_title",variations:{tower:{calibrations:["AspectRatioGE 0.9 0.8"],logo:l("logoMCImage","top",["7%","","70%",""]),button:l("clickTFText","bottom",["","","15%","10%"]),headline:l("text1TFText","top",["min(logo 6%, 15%)","10%","50%","10%"]),line:l("line","top",["headline 0","headline right 0","line 2px","headline left 0"]),description:l("text2TFText","top",["headline 20px","10%","button 6%","10%"])},square:{logo:l("logoMCImage","top left",["7%","","70%","7%"]),
button:l("clickTFText","bottom",["logo","","15%",""]),headline:l("text1TFText","top",["min(logo 6%, 15%)","10%","50%","10%"]),line:l("line","top",["headline 0","headline right 0","line 2px","headline left 0"]),description:l("text2TFText","top",["headline 20px","10%","button 6%","10%"])},banner1:{styles:{text1TFText:{padding:"5% 0%"},text2TFText:{padding:"5% 0%"}},calibrations:["AspectRatioLE 5.0 0.8"],logo:l("logoMCImage","left",["10%","50%","10%",""]),headline:l("text1TFText","left bottom",["10%",
"min(button 3%, 10%)","55%","min(logo 3%, 10%)"]),line:l("line","top",["headline 0","headline right 0","line 2px","headline left 0"]),description:l("text2TFText","left top",["headline 15px","min(button 3%, 10%)","10%","min(logo 3%, 10%)"]),button:l("clickTFText","right",["10%","3%","10%","50%"])},banner2:{calibrations:["AspectRatioLE 3.0 0.8"],styles:{text1TFText:{padding:"5% 0%"},text2TFText:{padding:"5% 0%"}},headline:l("text1TFText","left bottom",["10%","min(logo, button, 15%)","55%","5%"]),line:l("line",
"top",["headline 0","headline right 0","line 2px","headline left 0"]),description:l("text2TFText","left top",["headline 15px","min(logo, button, 15%)","10%","5%"]),logo:l("logoMCImage","right bottom",["20%","5%","40%","40%"]),button:l("logoMCImage","top right",["63%","3%","10%","40%"])},banner3:{calibrations:["AspectRatioLE 4 0"],logo:l("logoMCImage","left",["","70%","",""]),text1:l("text1TFText","left",["10%","50%","20%","logo 4%"]),text2:l("text2TFText","",["10%","button","10%","text1 4%"]),button:l("clickTFText",
"left right",["","","","80%"])},smallTower:{styles:X,text1:l("text1TFText","",["","","logoAndButton 10%",""]),text2:l("text2TFText","",["","","logoAndButton 10%",""],1),logoAndButton:{type:"vertical-list",spec:{elements:["clickTFText","logoMCImage"],margin:"auto",alignments:"bottom"},alignments:"bottom",top:"60%"}},smallSquare:{styles:X,text1:l("text1TFText","",["10px","","logoAndButton 10%",""]),text2:l("text2TFText","",["10px","","logoAndButton 10%",""],1),logoAndButton:{type:"horizontal-list",
spec:{elements:["logoMCImage","clickTFText"],margin:"even_left",alignments:"bottom"},alignments:"bottom",left:"10%",right:"10%",top:"50%",bottom:"10px"}},smallBanner:{styles:X,logo:l("logoMCImage","left",["","50%","","3%"]),text1:l("text1TFText","left",["2px","button","2px","logo 7%"]),text2:l("text2TFText","left",["2px","button","2px","logo 7%"],1),button:l("clickTFText","right",["","","","50%"])}}};
h("onAdData",function(b){window.renderAd(b,Y,function(){var c=document.getElementById("adContent").getAttribute("data-variation"),a=document.getElementById("adContent"),d=parseInt(a.style.width,10),a=parseInt(a.style.height,10),f=document.getElementById("border_vertical"),k=document.getElementById("border_horizontal"),g=Math.floor(.02*Math.sqrt(d*a));f.style.borderColor=V(W.verticalBorder,b);f.style.borderLeftWidth=g+"px";f.style.borderRightWidth=g+"px";f.style.margin=g+"px";f.style.width=d-4*g+"px";
f.style.height=a-2*g+"px";f.style.backgroundColor="transparent";k.style.borderColor=V(W.horizontalBorder,b);k.style.borderTopWidth=g+"px";k.style.borderBottomWidth=g+"px";k.style.margin=g+"px";k.style.width=d-2*g+"px";k.style.height=a-4*g+"px";k.style.backgroundColor="transparent";a=document.getElementById("arrow");a.innerHTML='<svg id="arrowIcon" viewBox="0 0 17 20"><polygon points="3,0 0,3 7,10 0,17 3,20 13,10"/></svg>';d=document.getElementById("button");f=parseInt(d.style.top,10);k=parseInt(d.style.left,
10);g=parseInt(d.style.height,10);if(-1<["smallTower","smallSquare","smallBanner"].indexOf(c)||!g||k<g)a.style.display="none";var n=.6*g;a.style.width=n+"px";a.style.height=n+"px";a.style.top=f+(g-n)/2+"px";a.style.left=k-n/2+"px";a.style.backgroundColor="transparent";a=document.getElementById("arrowIcon");a.style.width="100%";a.style.height="100%";a.childNodes[0].style.fill=d.style.color;(d=document.getElementById("button"))&&-1==c.indexOf("small")&&(d.style.backgroundColor="rgba(0, 0, 0, 0)");document.getElementById("line").style.backgroundColor=
document.getElementById("headline").style.color})});})()