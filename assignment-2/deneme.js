jQuery.ajaxPrefilter(function(options) {
  if (options.crossDomain && jQuery.support.cors) {
      options.url = 'https://cors-anywhere.herokuapp.com/' + options.url;
  }
});

$("#calculate").click(function (event) {
  let intA = document.getElementById("intA");
  let intB = document.getElementById("intB");
  switch(document.getElementById("operation").value) {
    case "Add":
        operation = "Add";
        break;
    case "Substract":
        operation = "Substract";
        break;
    case "Multiply":
        operation = "Multiply";
        break;
    case "Divide":
        operation = "Divide";
        break;
}

  var soapRequest = `<?xml version="1.0" encoding="utf-8"?>
                     <soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
                          <soap:Body>
                              <${operation} xmlns="http://tempuri.org/">
                                  <intA>${intA}</intA>
                                  <intB>${intB}</intB>
                              </${operation}>
                          </soap:Body>
                      </soap:Envelope>`;

  var webserUrl = "http://www.dneonline.com/calculator.asmx?WSDL";
  var self = this;
  self.disabled = true;
  $.ajax({
      type: "POST",
      url: webserUrl,
      dataType: "xml",
      processData: false,
      contentType: "text/xml; charset=\"utf-8\"",
      data: soapRequest,
      mode: "no-cors",
      success: function (data, status, req) {
          if (status == "success") {
              var result = $(req.responseXML).find(`${operation}Result`).text();
              $(`#${operation}Result`).val(result);
          }
      },
      error: function (data, status, req) {
          $('#errmsg').text(data.responseText);
      },
      complete: function(data, status) {
          self.disabled = false;
      }
  });
});