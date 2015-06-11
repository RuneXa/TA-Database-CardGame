
(function($){

  var loginhtml = '<div class="lbl nfo">Welcome back <a href="https://accounts.unity3d.com/users" id="unity-username"></a></div><div id="logout" class="lbl logout"><a href="">Log out</a></div>';

  $.fn.udnheader = function(options){
  
    var defaults = {
      app : 'Home',
      signinUrl : '',
      signoutUrl : '',
      username: ''
    };
  
    options = $.extend({}, defaults, options);

    if($.cookie('webauth_logged_in') != null){
                      
      $('.header-wrapper .user').html(loginhtml);
  
      if(options.username){
        $('#unity-username').html(options.username);
      }

      $('#logout a').bind('click',function(e){
        e.preventDefault();
        $(location).attr('href', options.signoutUrl);
      });
    }
    else {
      $('#login a').bind('click',function(e){
        e.preventDefault();
        $(location).attr('href', options.signinUrl);
      });
    }

  };

})(jQuery);

/**
 * jQuery Cookie plugin
 *
 * Copyright (c) 2010 Klaus Hartl (stilbuero.de)
 * Dual licensed under the MIT and GPL licenses:
 * http://www.opensource.org/licenses/mit-license.php
 * http://www.gnu.org/licenses/gpl.html
 *
 */
jQuery.cookie=function(e,t,n){if(arguments.length>1&&String(t)!=="[object Object]"){n=jQuery.extend({},n);if(t===null||t===undefined){n.expires=-1}if(typeof n.expires==="number"){var r=n.expires,i=n.expires=new Date;i.setDate(i.getDate()+r)}t=String(t);return document.cookie=[encodeURIComponent(e),"=",n.raw?t:encodeURIComponent(t),n.expires?"; expires="+n.expires.toUTCString():"",n.path?"; path="+n.path:"",n.domain?"; domain="+n.domain:"",n.secure?"; secure":""].join("")}n=t||{};var s,o=n.raw?function(e){return e}:decodeURIComponent;return(s=(new RegExp("(?:^|; )"+encodeURIComponent(e)+"=([^;]*)")).exec(document.cookie))?o(s[1]):null}
