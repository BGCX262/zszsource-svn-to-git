// JScript 文件

function send_Req(url,http_Req) {
	http_Req = false;		
	if(window.XMLHttpRequest) { 
		http_Req = new XMLHttpRequest();
		if (http_Req.overrideMimeType) {
			http_Req.overrideMimeType('text/xml');
		}
	}
	else if (window.ActiveXObject) { 
		try {
			http_Req = new ActiveXObject("Msxml2.XMLHTTP");
		} catch (e) {
			try {
				http_Req = new ActiveXObject("Microsoft.XMLHTTP");
			} catch (e) {}
		}
	}
	if (!http_Req) { 
		window.alert("不能创建XMLHttpRequest对象实例.");
		return ;
	}
	http_Req.onreadystatechange = function()
	{
		if (http_Req.readyState == 4) { 
			if (http_Req.status == 200) { 
				alert("更新成功！");	
			} else { 
				alert("您所请求的页面有异常。");
			}
		}
	}
	if(window.XMLHttpRequest) { 
		http_Req.open("GET", url, true);
	}
	else
	{
		http_Req.open("POST", url, true);
	}
	http_Req.send(null);
}