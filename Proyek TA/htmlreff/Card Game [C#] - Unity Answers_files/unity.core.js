/* Modernizr v2.5.3 www.modernizr.com */
window.Modernizr=function(a,b,c){function D(a){j.cssText=a}function E(a,b){return D(n.join(a+";")+(b||""))}function F(a,b){return typeof a===b}function G(a,b){return!!~(""+a).indexOf(b)}function H(a,b){for(var d in a){if(j[a[d]]!==c){return b=="pfx"?a[d]:true}}return false}function I(a,b,d){for(var e in a){var f=b[a[e]];if(f!==c){if(d===false)return a[e];if(F(f,"function")){return f.bind(d||b)}return f}}return false}function J(a,b,c){var d=a.charAt(0).toUpperCase()+a.substr(1),e=(a+" "+p.join(d+" ")+d).split(" ");if(F(b,"string")||F(b,"undefined")){return H(e,b)}else{e=(a+" "+q.join(d+" ")+d).split(" ");return I(e,b,c)}}function L(){e["input"]=function(c){for(var d=0,e=c.length;d<e;d++){u[c[d]]=!!(c[d]in k)}if(u.list){u.list=!!(b.createElement("datalist")&&a.HTMLDataListElement)}return u}("autocomplete autofocus list placeholder max min multiple pattern required step".split(" "));e["inputtypes"]=function(a){for(var d=0,e,f,h,i=a.length;d<i;d++){k.setAttribute("type",f=a[d]);e=k.type!=="text";if(e){k.value=l;k.style.cssText="position:absolute;visibility:hidden;";if(/^range$/.test(f)&&k.style.WebkitAppearance!==c){g.appendChild(k);h=b.defaultView;e=h.getComputedStyle&&h.getComputedStyle(k,null).WebkitAppearance!=="textfield"&&k.offsetHeight!==0;g.removeChild(k)}else if(/^(search|tel)$/.test(f)){}else if(/^(url|email)$/.test(f)){e=k.checkValidity&&k.checkValidity()===false}else if(/^color$/.test(f)){g.appendChild(k);g.offsetWidth;e=k.value!=l;g.removeChild(k)}else{e=k.value!=l}}t[a[d]]=!!e}return t}("search tel url email datetime date month week time datetime-local number range color".split(" "))}var d="2.5.3",e={},f=true,g=b.documentElement,h="modernizr",i=b.createElement(h),j=i.style,k=b.createElement("input"),l=":)",m={}.toString,n=" -webkit- -moz- -o- -ms- ".split(" "),o="Webkit Moz O ms",p=o.split(" "),q=o.toLowerCase().split(" "),r={svg:"http://www.w3.org/2000/svg"},s={},t={},u={},v=[],w=v.slice,x,y=function(a,c,d,e){var f,i,j,k=b.createElement("div"),l=b.body,m=l?l:b.createElement("body");if(parseInt(d,10)){while(d--){j=b.createElement("div");j.id=e?e[d]:h+(d+1);k.appendChild(j)}}f=["&#173;","<style>",a,"</style>"].join("");k.id=h;m.innerHTML+=f;m.appendChild(k);if(!l){m.style.background="";g.appendChild(m)}i=c(k,a);!l?m.parentNode.removeChild(m):k.parentNode.removeChild(k);return!!i},z=function(b){var c=a.matchMedia||a.msMatchMedia;if(c){return c(b).matches}var d;y("@media "+b+" { #"+h+" { position: absolute; } }",function(b){d=(a.getComputedStyle?getComputedStyle(b,null):b.currentStyle)["position"]=="absolute"});return d},A=function(){function d(d,e){e=e||b.createElement(a[d]||"div");d="on"+d;var f=d in e;if(!f){if(!e.setAttribute){e=b.createElement("div")}if(e.setAttribute&&e.removeAttribute){e.setAttribute(d,"");f=F(e[d],"function");if(!F(e[d],"undefined")){e[d]=c}e.removeAttribute(d)}}e=null;return f}var a={select:"input",change:"input",submit:"form",reset:"form",error:"img",load:"img",abort:"img"};return d}();var B={}.hasOwnProperty,C;if(!F(B,"undefined")&&!F(B.call,"undefined")){C=function(a,b){return B.call(a,b)}}else{C=function(a,b){return b in a&&F(a.constructor.prototype[b],"undefined")}}if(!Function.prototype.bind){Function.prototype.bind=function(b){var c=this;if(typeof c!="function"){throw new TypeError}var d=w.call(arguments,1),e=function(){if(this instanceof e){var a=function(){};a.prototype=c.prototype;var f=new a;var g=c.apply(f,d.concat(w.call(arguments)));if(Object(g)===g){return g}return f}else{return c.apply(b,d.concat(w.call(arguments)))}};return e}}var K=function(c,d){var f=c.join(""),g=d.length;y(f,function(c,d){var f=b.styleSheets[b.styleSheets.length-1],h=f?f.cssRules&&f.cssRules[0]?f.cssRules[0].cssText:f.cssText||"":"",i=c.childNodes,j={};while(g--){j[i[g].id]=i[g]}e["touch"]="ontouchstart"in a||a.DocumentTouch&&b instanceof DocumentTouch||(j["touch"]&&j["touch"].offsetTop)===9;e["csstransforms3d"]=(j["csstransforms3d"]&&j["csstransforms3d"].offsetLeft)===9&&j["csstransforms3d"].offsetHeight===3;e["generatedcontent"]=(j["generatedcontent"]&&j["generatedcontent"].offsetHeight)>=1;e["fontface"]=/src/i.test(h)&&h.indexOf(d.split(" ")[0])===0},g,d)}(['@font-face {font-family:"font";src:url("https://")}',["@media (",n.join("touch-enabled),("),h,")","{#touch{top:9px;position:absolute}}"].join(""),["@media (",n.join("transform-3d),("),h,")","{#csstransforms3d{left:9px;position:absolute;height:3px;}}"].join(""),['#generatedcontent:after{content:"',l,'";visibility:hidden}'].join("")],["fontface","touch","csstransforms3d","generatedcontent"]);s["flexbox"]=function(){return J("flexOrder")};s["flexbox-legacy"]=function(){return J("boxDirection")};s["canvas"]=function(){var a=b.createElement("canvas");return!!(a.getContext&&a.getContext("2d"))};s["canvastext"]=function(){return!!(e["canvas"]&&F(b.createElement("canvas").getContext("2d").fillText,"function"))};s["webgl"]=function(){try{var d=b.createElement("canvas"),e;e=!!(a.WebGLRenderingContext&&(d.getContext("experimental-webgl")||d.getContext("webgl")));d=c}catch(f){e=false}return e};s["touch"]=function(){return e["touch"]};s["geolocation"]=function(){return!!navigator.geolocation};s["postmessage"]=function(){return!!a.postMessage};s["websqldatabase"]=function(){return!!a.openDatabase};s["indexedDB"]=function(){return!!J("indexedDB",a)};s["hashchange"]=function(){return A("hashchange",a)&&(b.documentMode===c||b.documentMode>7)};s["history"]=function(){return!!(a.history&&history.pushState)};s["draganddrop"]=function(){var a=b.createElement("div");return"draggable"in a||"ondragstart"in a&&"ondrop"in a};s["websockets"]=function(){for(var b=-1,c=p.length;++b<c;){if(a[p[b]+"WebSocket"]){return true}}return"WebSocket"in a};s["rgba"]=function(){D("background-color:rgba(150,255,150,.5)");return G(j.backgroundColor,"rgba")};s["hsla"]=function(){D("background-color:hsla(120,40%,100%,.5)");return G(j.backgroundColor,"rgba")||G(j.backgroundColor,"hsla")};s["multiplebgs"]=function(){D("background:url(https://),url(https://),red url(https://)");return/(url\s*\(.*?){3}/.test(j.background)};s["backgroundsize"]=function(){return J("backgroundSize")};s["borderimage"]=function(){return J("borderImage")};s["borderradius"]=function(){return J("borderRadius")};s["boxshadow"]=function(){return J("boxShadow")};s["textshadow"]=function(){return b.createElement("div").style.textShadow===""};s["opacity"]=function(){E("opacity:.55");return/^0.55$/.test(j.opacity)};s["cssanimations"]=function(){return J("animationName")};s["csscolumns"]=function(){return J("columnCount")};s["cssgradients"]=function(){var a="background-image:",b="gradient(linear,left top,right bottom,from(#9f9),to(white));",c="linear-gradient(left top,#9f9, white);";D((a+"-webkit- ".split(" ").join(b+a)+n.join(c+a)).slice(0,-a.length));return G(j.backgroundImage,"gradient")};s["cssreflections"]=function(){return J("boxReflect")};s["csstransforms"]=function(){return!!J("transform")};s["csstransforms3d"]=function(){var a=!!J("perspective");if(a&&"webkitPerspective"in g.style){a=e["csstransforms3d"]}return a};s["csstransitions"]=function(){return J("transition")};s["fontface"]=function(){return e["fontface"]};s["generatedcontent"]=function(){return e["generatedcontent"]};s["video"]=function(){var a=b.createElement("video"),c=false;try{if(c=!!a.canPlayType){c=new Boolean(c);c.ogg=a.canPlayType('video/ogg; codecs="theora"').replace(/^no$/,"");c.h264=a.canPlayType('video/mp4; codecs="avc1.42E01E"').replace(/^no$/,"");c.webm=a.canPlayType('video/webm; codecs="vp8, vorbis"').replace(/^no$/,"")}}catch(d){}return c};s["audio"]=function(){var a=b.createElement("audio"),c=false;try{if(c=!!a.canPlayType){c=new Boolean(c);c.ogg=a.canPlayType('audio/ogg; codecs="vorbis"').replace(/^no$/,"");c.mp3=a.canPlayType("audio/mpeg;").replace(/^no$/,"");c.wav=a.canPlayType('audio/wav; codecs="1"').replace(/^no$/,"");c.m4a=(a.canPlayType("audio/x-m4a;")||a.canPlayType("audio/aac;")).replace(/^no$/,"")}}catch(d){}return c};s["localstorage"]=function(){try{localStorage.setItem(h,h);localStorage.removeItem(h);return true}catch(a){return false}};s["sessionstorage"]=function(){try{sessionStorage.setItem(h,h);sessionStorage.removeItem(h);return true}catch(a){return false}};s["webworkers"]=function(){return!!a.Worker};s["applicationcache"]=function(){return!!a.applicationCache};s["svg"]=function(){return!!b.createElementNS&&!!b.createElementNS(r.svg,"svg").createSVGRect};s["inlinesvg"]=function(){var a=b.createElement("div");a.innerHTML="<svg/>";return(a.firstChild&&a.firstChild.namespaceURI)==r.svg};s["smil"]=function(){return!!b.createElementNS&&/SVGAnimate/.test(m.call(b.createElementNS(r.svg,"animate")))};s["svgclippaths"]=function(){return!!b.createElementNS&&/SVGClipPath/.test(m.call(b.createElementNS(r.svg,"clipPath")))};for(var M in s){if(C(s,M)){x=M.toLowerCase();e[x]=s[M]();v.push((e[x]?"":"no-")+x)}}e.input||L();e.addTest=function(a,b){if(typeof a=="object"){for(var d in a){if(C(a,d)){e.addTest(d,a[d])}}}else{a=a.toLowerCase();if(e[a]!==c){return e}b=typeof b=="function"?b():b;g.className+=" "+(b?"":"no-")+a;e[a]=b}return e};D("");i=k=null;(function(a,b){function g(a,b){var c=a.createElement("p"),d=a.getElementsByTagName("head")[0]||a.documentElement;c.innerHTML="x<style>"+b+"</style>";return d.insertBefore(c.lastChild,d.firstChild)}function h(){var a=k.elements;return typeof a=="string"?a.split(" "):a}function i(a){var b={},c=a.createElement,e=a.createDocumentFragment,f=e();a.createElement=function(a){var e=(b[a]||(b[a]=c(a))).cloneNode();return k.shivMethods&&e.canHaveChildren&&!d.test(a)?f.appendChild(e):e};a.createDocumentFragment=Function("h,f","return function(){"+"var n=f.cloneNode(),c=n.createElement;"+"h.shivMethods&&("+h().join().replace(/\w+/g,function(a){b[a]=c(a);f.createElement(a);return'c("'+a+'")'})+");return n}")(k,f)}function j(a){var b;if(a.documentShived){return a}if(k.shivCSS&&!e){b=!!g(a,"article,aside,details,figcaption,figure,footer,header,hgroup,nav,section{display:block}"+"audio{display:none}"+"canvas,video{display:inline-block;*display:inline;*zoom:1}"+"[hidden]{display:none}audio[controls]{display:inline-block;*display:inline;*zoom:1}"+"mark{background:#FF0;color:#000}")}if(!f){b=!i(a)}if(b){a.documentShived=b}return a}var c=a.html5||{};var d=/^<|^(?:button|form|map|select|textarea)$/i;var e;var f;(function(){var a=b.createElement("a");a.innerHTML="<xyz></xyz>";e="hidden"in a;f=a.childNodes.length==1||function(){try{b.createElement("a")}catch(a){return true}var c=b.createDocumentFragment();return typeof c.cloneNode=="undefined"||typeof c.createDocumentFragment=="undefined"||typeof c.createElement=="undefined"}()})();var k={elements:c.elements||"abbr article aside audio bdi canvas data datalist details figcaption figure footer header hgroup mark meter nav output progress section summary time video",shivCSS:!(c.shivCSS===false),shivMethods:!(c.shivMethods===false),type:"default",shivDocument:j};a.html5=k;j(b)})(this,b);e._version=d;e._prefixes=n;e._domPrefixes=q;e._cssomPrefixes=p;e.mq=z;e.hasEvent=A;e.testProp=function(a){return H([a])};e.testAllProps=J;e.testStyles=y;e.prefixed=function(a,b,c){if(!b){return J(a,"pfx")}else{return J(a,b,c)}};g.className=g.className.replace(/(^|\s)no-js(\s|$)/,"$1$2")+(f?" js "+v.join(" "):"");return e}(this,this.document)

var touchEnabled;
var masterW;

$(document).ready(function(){

  // Init
  touchEnabled = (Modernizr.touch) ? true : false;
  masterW = parseInt($('.gw').css('width'));
  menuRendering();

  // Sets prefered language cookie
  $('.flag a').click(function(e){
    var code = $(this).attr('data-lang');
    $.cookie('lang_pref', code, { expires: 30, path: '/', domain: 'unity3d.com' });
  });

  // Toggle anything
  $('.toggle').bind('click',function(e){
    e.preventDefault();
    var el = $(this).attr('data-target');
    if(el.indexOf('|') < 1){
      ($(el).css('display') == 'block') ? $(el).hide() : $(el).show();
    }
    else {
      el = el.split('|');
      $('.' + el[1]).hide();
      $('#' + el[0]).show();
    }
  });

  // Toggle search
  $('.search-icon').click(function(){
    var pos = (masterW < 441) ? $(this).offset().left + 47 : $(this).offset().left - parseInt($('.unity-search').outerWidth(true));
    $('.unity-search').css('left',pos);
    $('.unity-search').toggle();
    $('.unity-search input[type=text]').focus();
  });

  // Tool buttons tip
  if(!touchEnabled){
    $('.tt').hover(function(){
      var d = $(this).attr('data-distance').split('|');
      $('.tip', $(this)).css('top',d[0]+'px');
      (d[2] == 'top') ? $('.tip', $(this)).addClass('t') : $('.tip', $(this)).addClass('b');
      centerElement($(this), '.tip', true);
      $(this).find('.tip').stop(true, true).removeClass('hide').animate({ 'top': d[1], 'opacity': 1 }, 200 );
    },function(){
      var d = $(this).attr('data-distance').split('|');
      $(this).find('.tip').stop(true, false).animate({ 'top': d[0], 'opacity': 0 }, 200, function(){
        $(this).addClass('hide');
      });
    });
  }

  // Replace select boxes
  $('.fancy-select select').customSelect();
  
  // Fancy select change function
  $('.fancy-select select').change(function(){
    var parent = $(this).parent().parent().parent().parent();
    $('form',parent).submit();
  });

  // Hide elements on body click/touch
  $('html').bind('click', function(e){
    if($(e.target).closest('.section-nav .g12').length == 0 && masterW < 441){ $('.section-nav ul').removeAttr('style'); }
    if($(e.target).closest('.lang-switcher').length == 0){ $('.lang-list').hide(); }
    if($(e.target).closest('.search-icon').length == 0 && $(e.target).closest('.unity-search').length == 0 && $(e.target).closest('.m-searchbtn').length == 0){ $('.unity-search').hide(); }
  });
  window.addEventListener('orientationchange', function(){
    $('.unity-search').hide();
    $('.unity-search input').blur();
  });

  // Toggle menu
  $('.m-navbtn').click(function(){
    $('#section-header').toggleClass('m-nav-visible');
    var bh = ($('.section-content').outerHeight(true) > getHeight()) ? $('.section-content').outerHeight(true) : getHeight();
    if(bh == 0) bh = getHeight();
    if(bh < parseInt($('#section-header').css('height'))) bh = parseInt($('#section-header').css('height'));
    $('#section-header').css('height', bh);
    $('.overlay').css('height', bh);
    $('.overlay').show();
    ($('iframe').css('display') == 'none') ? $('iframe, object').show() : $('iframe, object').hide();
  });

  // Mobile search
  $('.m-searchbtn').click(function(e){
    e.stopImmediatePropagation();
    if(!$(this).hasClass('open')){
      $('.section-nav').animate({ 'height': '76px' }, 300, function(){
        $('.search-wrapper').fadeIn(200);
        $('.search-wrapper input[type=text]').focus();
      });
      $(this).addClass('open');
    }
    else {
      $('.search-wrapper').hide();
      $('.section-nav').animate({ 'height': '35px' });
      $(this).removeClass('open');
    }
  });

  $('.overlay').bind('click', function(){ closeMenu(); });
  $('.overlay').hammer().bind('tap', function(){ closeMenu(); });

  function closeMenu(){
    $('#section-header').removeClass('m-nav-visible').css('height','auto');
    $('iframe, object').show();
    $('.overlay').hide();
  }

  $('.section-nav .g12').click(function(e){
    masterW = parseInt($('.gw').css('width'));
    if(masterW < 441) $('.section-nav ul').toggle();
  });

  $(window).resize(function(){
    //$('#content, #section-header').removeAttr('style').removeClass('m-nav-visible');
    //$('.overlay').hide();
    $('.m-searchbtn').removeClass('open');
    $('.unity-search').hide();
    $('.search-wrapper, .section-nav').removeAttr('style');
  });

});

function menuRendering(){
  masterW = parseInt($('.gw').css('width'));
  if(masterW < 441 && $('.section-nav ul').length > -1){
    if($('.section-nav .label').length == 0){
      var label = $('.section-nav li a.active-trail').text(); 
      $('.section-nav .g12').prepend('<div class="label">'+ label +'</div>');
    }
  } else if(masterW > 440 && $('.section-nav .label').length > 0){
    $('.section-nav .label').remove();
    $('.section-nav ul').removeAttr('style');
  }
}
function modalMessage(el){
  el.fadeIn(300);setTimeout(function(){ el.fadeOut(300); }, 3000);
}
function centerElement(parent,child,nested){
  // this, tip, 
  if(nested){
    var el = parent.find(child);
    el.css('width', el.width());
    el.css('left', (parent.outerWidth(true) - el.outerWidth(true)/2 - parent.outerWidth(true)/2) - 3);
  }
}
function getHeight(){ if(typeof window.innerHeight != 'undefined'){var viewportheight = window.innerHeight;} else if(typeof document.documentElement != 'undefined' && typeof document.documentElement.clientHeight != 'undefined' && document.documentElement.clientHeight != 0){var viewportheight = document.documentElement.clientHeight;} else {var viewportheight = document.getElementsByTagName('body')[0].clientHeight;} return viewportheight; }
function getWidth(){ if (typeof window.innerWidth != 'undefined'){var viewportwidth = window.innerWidth;} else if (typeof document.documentElement != 'undefined' && typeof document.documentElement.clientWidth != 'undefined' && document.documentElement.clientWidth != 0){var viewportwidth = document.documentElement.clientWidth;} else {var viewportwidth = document.getElementsByTagName('body')[0].clientWidth;} return viewportwidth; }

/* Hammer.JS jQuery plugin * version 0.3 * author: Eight Media * https://github.com/EightMedia/hammer.js */
function Hammer(e,t,n){function T(e){return e.touches?e.touches.length:1}function N(e){var t=document,n=t.body;return[{x:e.pageX||e.clientX+(t&&t.scrollLeft||n&&n.scrollLeft||0)-(t&&t.clientLeft||n&&t.clientLeft||0),y:e.pageY||e.clientY+(t&&t.scrollTop||n&&n.scrollTop||0)-(t&&t.clientTop||n&&t.clientTop||0)}]}function C(e){var n=[],r;for(var i=0,s=t.two_touch_max?Math.min(2,e.touches.length):e.touches.length;i<s;i++){r=e.touches[i];n.push({x:r.pageX,y:r.pageY})}return n}function k(e){var r=N;e=e||window.event;if(!S){if(t.allow_touch_and_mouse&&e.touches!==n&&e.touches.length>0){r=C}}else{r=C}return r(e)}function L(e,t){return Math.atan2(t.y-e.y,t.x-e.x)*180/Math.PI}function A(e,t){var n=t.x-e.x,r=t.y-e.y;return Math.sqrt(n*n+r*r)}function O(e,t){if(e.length==2&&t.length==2){var n=A(e[0],e[1]);var r=A(t[0],t[1]);return r/n}return 0}function M(e,t){if(e.length==2&&t.length==2){var n=L(e[1],e[0]);var r=L(t[1],t[0]);return r-n}return 0}function _(e,t){t.touches=k(t.originalEvent);t.type=e;if(q(r["on"+e])){r["on"+e].call(r,t)}}function D(e){e=e||window.event;if(e.preventDefault){e.preventDefault();e.stopPropagation()}else{e.returnValue=false;e.cancelBubble=true}}function P(){a={};l=false;f=0;s=0;o=0;c=null}function B(n){function m(){a.start=k(n);p=(new Date).getTime();f=T(n);l=true;b=n;var t=e.getBoundingClientRect();var r=e.clientTop||document.body.clientTop||0;var i=e.clientLeft||document.body.clientLeft||0;var s=window.pageYOffset||e.scrollTop||document.body.scrollTop;var o=window.pageXOffset||e.scrollLeft||document.body.scrollLeft;g={top:t.top+s-r,left:t.left+o-i};y=true;H.hold(n)}var r;switch(n.type){case"mousedown":case"touchstart":r=T(n);x=r===1;if(r===2&&c==="drag"){_("dragend",{originalEvent:n,direction:u,distance:s,angle:o})}m();if(t.prevent_default){D(n)}break;case"mousemove":case"touchmove":r=T(n);if(!y&&r===1){return false}else if(!y&&r===2){x=false;P();m()}w=n;a.move=k(n);if(!H.transform(n)){H.drag(n)}break;case"mouseup":case"mouseout":case"touchcancel":case"touchend":var i=true;y=false;E=n;H.swipe(n);if(c=="drag"){_("dragend",{originalEvent:n,direction:u,distance:s,angle:o})}else if(c=="transform"){var d=a.center.x-a.startCenter.x;var v=a.center.y-a.startCenter.y;_("transformend",{originalEvent:n,position:a.center,scale:O(a.start,a.move),rotation:M(a.start,a.move),distance:s,distanceX:d,distanceY:v});if(T(n)===1){P();m();i=false}}else if(x&&n.type!="mouseout"){H.tap(b)}if(c!==null){h=c;_("release",{originalEvent:n,gesture:c,position:a.move||a.start})}if(i){P()}break}}function j(t){if(!F(e,t.relatedTarget)){B(t)}}function F(e,t){if(!t&&window.event&&window.event.toElement){t=window.event.toElement}if(e===t){return true}if(t){var n=t.parentNode;while(n!==null){if(n===e){return true}n=n.parentNode}}return false}function I(e,t){var n={};if(!t){return e}for(var r in e){if(r in t){n[r]=t[r]}else{n[r]=e[r]}}return n}function q(e){return Object.prototype.toString.call(e)=="[object Function]"}function R(e,t,n){t=t.split(" ");for(var r=0,i=t.length;r<i;r++){if(e.addEventListener){e.addEventListener(t[r],n,false)}else if(document.attachEvent){e.attachEvent("on"+t[r],n)}}}function U(e,t,n){t=t.split(" ");for(var r=0,i=t.length;r<i;r++){if(e.removeEventListener){e.removeEventListener(t[r],n,false)}else if(document.detachEvent){e.detachEvent("on"+t[r],n)}}}var r=this;var i=I({prevent_default:false,css_hacks:true,swipe:true,swipe_time:500,swipe_min_distance:20,drag:true,drag_vertical:true,drag_horizontal:true,drag_min_distance:20,transform:true,scale_treshold:.1,rotation_treshold:15,tap:true,tap_double:true,tap_max_interval:300,tap_max_distance:10,tap_double_distance:20,hold:true,hold_timeout:500,allow_touch_and_mouse:false},Hammer.defaults||{});t=I(i,t);(function(){if(!t.css_hacks){return false}var n=["webkit","moz","ms","o",""];var r={userSelect:"none",touchCallout:"none",touchAction:"none",userDrag:"none",tapHighlightColor:"rgba(0,0,0,0)"};var i="";for(var s=0;s<n.length;s++){for(var o in r){i=o;if(n[s]){i=n[s]+i.substring(0,1).toUpperCase()+i.substring(1)}e.style[i]=r[o]}}})();var s=0;var o=0;var u=0;var a={};var f=0;var l=false;var c=null;var h=null;var p=null;var d={x:0,y:0};var v=null;var m=null;var g={};var y=false;var b;var w;var E;var S="ontouchstart"in window;var x=false;this.option=function(e,r){if(r!==n){t[e]=r}return t[e]};this.getDirectionFromAngle=function(e){var t={down:e>=45&&e<135,left:e>=135||e<=-135,up:e<-45&&e>-135,right:e>=-45&&e<=45};var n,r;for(r in t){if(t[r]){n=r;break}}return n};this.destroy=function(){if(S||t.allow_touch_and_mouse){U(e,"touchstart touchmove touchend touchcancel",B)}if(!S||t.allow_touch_and_mouse){U(e,"mouseup mousedown mousemove",B);U(e,"mouseout",j)}};var H={hold:function(e){if(t.hold){c="hold";clearTimeout(m);m=setTimeout(function(){if(c=="hold"){_("hold",{originalEvent:e,position:a.start})}},t.hold_timeout)}},swipe:function(e){if(!a.move||c==="transform"){return}var n=a.move[0].x-a.start[0].x;var i=a.move[0].y-a.start[0].y;s=Math.sqrt(n*n+i*i);var f=(new Date).getTime();var l=f-p;if(t.swipe&&t.swipe_time>=l&&s>=t.swipe_min_distance){o=L(a.start[0],a.move[0]);u=r.getDirectionFromAngle(o);c="swipe";var h={x:a.move[0].x-g.left,y:a.move[0].y-g.top};var d={originalEvent:e,position:h,direction:u,distance:s,distanceX:n,distanceY:i,angle:o};_("swipe",d)}},drag:function(e){var n=a.move[0].x-a.start[0].x;var i=a.move[0].y-a.start[0].y;s=Math.sqrt(n*n+i*i);if(t.drag&&s>t.drag_min_distance||c=="drag"){o=L(a.start[0],a.move[0]);u=r.getDirectionFromAngle(o);var f=u=="up"||u=="down";if((f&&!t.drag_vertical||!f&&!t.drag_horizontal)&&s>t.drag_min_distance){return}c="drag";var h={x:a.move[0].x-g.left,y:a.move[0].y-g.top};var p={originalEvent:e,position:h,direction:u,distance:s,distanceX:n,distanceY:i,angle:o};if(l){_("dragstart",p);l=false}_("drag",p);D(e)}},transform:function(e){if(t.transform){var n=T(e);if(n!==2){return false}var r=M(a.start,a.move);var i=O(a.start,a.move);if(c==="transform"||Math.abs(1-i)>t.scale_treshold||Math.abs(r)>t.rotation_treshold){c="transform";a.center={x:(a.move[0].x+a.move[1].x)/2-g.left,y:(a.move[0].y+a.move[1].y)/2-g.top};if(l)a.startCenter=a.center;var o=a.center.x-a.startCenter.x;var u=a.center.y-a.startCenter.y;s=Math.sqrt(o*o+u*u);var f={originalEvent:e,position:a.center,scale:i,rotation:r,distance:s,distanceX:o,distanceY:u};if(l){_("transformstart",f);l=false}_("transform",f);D(e);return true}}return false},tap:function(e){var n=(new Date).getTime();var r=n-p;if(t.hold&&!(t.hold&&t.hold_timeout>r)){return}var i=function(){if(d&&t.tap_double&&h=="tap"&&a.start&&p-v<t.tap_max_interval){var e=Math.abs(d[0].x-a.start[0].x);var n=Math.abs(d[0].y-a.start[0].y);return d&&a.start&&Math.max(e,n)<t.tap_double_distance}return false}();if(i){c="double_tap";v=null;_("doubletap",{originalEvent:e,position:a.start});D(e)}else{var o=a.move?Math.abs(a.move[0].x-a.start[0].x):0;var u=a.move?Math.abs(a.move[0].y-a.start[0].y):0;s=Math.max(o,u);if(s<t.tap_max_distance){c="tap";v=n;d=a.start;if(t.tap){_("tap",{originalEvent:e,position:a.start});D(e)}}}}};if(S||t.allow_touch_and_mouse){R(e,"touchstart touchmove touchend touchcancel",B)}if(!S||t.allow_touch_and_mouse){R(e,"mouseup mousedown mousemove",B);R(e,"mouseout",j)}}
jQuery.fn.hammer = function(options){return this.each(function(){var hammer = new Hammer(this, options);var $el = jQuery(this);$el.data("hammer", hammer);var events = ['hold','tap','doubletap','transformstart','transform','transformend','dragstart','drag','dragend','swipe','release'];for(var e=0; e<events.length; e++){hammer['on'+ events[e]] = (function(el, eventName) {return function(ev) {el.trigger(jQuery.Event(eventName, ev));};})($el, events[e]);}});};

/* jquery.customSelect() - v0.4.1 - http://adam.co/lab/jquery/customselect/ */
(function(e){"use strict";e.fn.extend({customSelect:function(t){if(typeof document.body.style.maxHeight==="undefined"){return this}var n={customClass:"customSelect",mapClass:true,mapStyle:true},t=e.extend(n,t),r=t.customClass,i=function(t,n,r){var i=t.find(":selected"),o=n.children(":first"),u=i.html()||" ";o.html('<div class="arrow"></div><span class="lbl">'+r+" "+u+"</span>");if(i.attr("disabled")){n.addClass(s("DisabledOption"))}else{n.removeClass(s("DisabledOption"))}setTimeout(function(){n.removeClass(s("Open"));e(document).off("mouseup."+s("Open"))},60)},s=function(e){return r+e};return this.each(function(){var n=e(this),o=e("<span />").addClass(s("Inner")),u=e("<span />");n.after(u.append(o));var a=e(this).prev("label").text();u.addClass(r);if(t.mapClass){u.addClass(n.attr("class"))}if(t.mapStyle){u.attr("style",n.attr("style"))}n.addClass("hasCustomSelect").on("update",function(){i(n,u,a);var e=parseInt(n.outerWidth(),10)-(parseInt(u.outerWidth(),10)-parseInt(u.width(),10));e="auto";u.css({display:"inline-block"});var t=u.outerHeight();if(n.attr("disabled")){u.addClass(s("Disabled"))}else{u.removeClass(s("Disabled"))}o.css({width:e,display:"inline-block"});n.css({"-webkit-appearance":"menulist-button",width:u.outerWidth(),position:"absolute","z-index":999,opacity:0,height:t,fontSize:u.css("font-size")})}).on("change",function(){u.addClass(s("Changed"));i(n,u,a)}).on("keyup",function(e){if(!u.hasClass(s("Open"))){n.blur();n.focus()}else{if(e.which==13||e.which==27){i(n,u,a)}}}).on("mousedown",function(e){u.removeClass(s("Changed"))}).on("mouseup",function(t){if(!u.hasClass(s("Open"))){if(e("."+s("Open")).not(u).length>0&&typeof InstallTrigger!=="undefined"){n.focus()}else{u.addClass(s("Open"));t.stopPropagation();e(document).one("mouseup."+s("Open"),function(t){if(t.target!=n.get(0)&&e.inArray(t.target,n.find("*").get())<0){n.blur()}else{i(n,u,a)}})}}}).focus(function(){u.removeClass(s("Changed")).addClass(s("Focus"))}).blur(function(){u.removeClass(s("Focus")+" "+s("Open"))}).hover(function(){u.addClass(s("Hover"))},function(){u.removeClass(s("Hover"))}).trigger("update")})}})})(jQuery)
