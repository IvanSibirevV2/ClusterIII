
//Start phpRequest Object
function AjaxRequest(serverUrl, ID)
{
    
  //Set some default variables
    this.parms = new Array();
    this.parmsIndex = 0;
 
  //Set the server url
    this.server = serverUrl;
    this.requestMethod = 'GET';
 
    this.id = ID;
    this.handler = null;
    this.httpRequest = null;
    this.resultXML = null;
    var currentObject = this;
  
    this.execute = function ()
	{
		//Try to create our XMLHttpRequest Object
		try
		{
			this.httpRequest = this.createXMLHttp();
			httpRequest = this.httpRequest;
		}
		catch (e)
		{
			alert('Error creating the connection!');
			return;
		}
		
		//Make the connection and send our data
		try
		{
			var txt = "?1";
			for(var i in this.parms)
			{
			  txt = txt + '&'+this.parms[i].name + '=' + this.parms[i].value;
			}

			if (this.requestMethod == 'GET')
			{
			    httpRequest.open("GET", this.server + txt, true);
			    httpRequest.setRequestHeader('content-type', 'text/xml');
			    // alert(this.server + " " + txt);
			}
			else
			{
			    httpRequest.open("POST", this.server + txt, true);
			    httpRequest.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
			}
			
			// alert(this.server + txt);
			// document.write(this.server + txt);
			httpRequest.onreadystatechange = this.AJAXRequest_onReadyStateChange;
			httpRequest.send('');
			
			
		}
		catch (e)
		{
			//alert('An error has occured calling the external site: ' + e);
			return false;
		}
		
	}
	
	// --- AJAX onreadystatechange handler --- //
		this.AJAXRequest_onReadyStateChange = function ()
		{
			if (httpRequest.readyState != 4) return;
			
			if (httpRequest.status == 200)
			{
			    
				// --- create xml document object
				
			    if (typeof(httpRequest.responseXML.documentElement) != 'undefined')
			    {
			        resultXML = httpRequest.responseXML.documentElement;
			    }
			    else
			    {
			        XMLDocument = new ActiveXObject("Msxml2.DOMDocument");
			        XMLDocument.loadXML(httpRequest.responseText);
		
			        resultXML = XMLDocument;
			    }
				
			}
			else
			{
				// alert('The server respond with a bad status code: ' + httpRequest.status);
		        return false;
			}
			
			// --- Load current handler--- //
			currentObject.resultXML = resultXML;
			if (typeof(handler) == 'function') handler(currentObject);
				
			// alert(resultXML.getElementsByTagName('control')[0].firstChild.data);
			return resultXML;
		}
	// --- AJAX onreadystatechange handler --- //
	
	this.setHandler = function (handlerName)
	{
		handler = handlerName;
	}
	
	this.setRequestMethod = function (methodName)
	{
	    if (methodName == 'POST') 
	    {
	        this.requestMethod = 'POST';
	    }
	    else
	    {
	        this.requestMethod = 'GET';
	    }
	}
	
	this.add = function (name, value)
	{
	  //Add a new pair object to the params
	  this.parms[this.parmsIndex] = new pair(name,value);
	  this.parmsIndex++;
	}
	
	this.createXMLHttp = function ()
	{
		// var httpRequest = null;
	    try
	    {
	        httpRequest = new ActiveXObject('Msxml2.XMLHTTP');
	    }
	    catch (e)
	    {
	        try
	        {
	            httpRequest = new ActiveXObject('Microsoft.XMLHTTP');
	        }
	        catch (ee)
	        {
	            httpRequest = null;
	        }
	    }
	    
	    if (!httpRequest && typeof XMLHttpRequest != 'undefined')
	    {
	    	httpRequest = new XMLHttpRequest();
	    }
	
	    return httpRequest;
	}
  
}


//Utility pair class
function pair(name, value)
{
  this.name = name;
  this.value = value;
}