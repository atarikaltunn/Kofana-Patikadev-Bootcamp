function onSubmit() {
    let operation = "";
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

    const myHeaders = new Headers();
    myHeaders.append("Content-Type", "text/xml; charset=utf-8");
    myHeaders.append("SOAPAction", `http://tempuri.org/${operation}`);

    var raw = `<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">\n  <soap:Body>\n    <${intA} xmlns=\"http://tempuri.org/\">\n      <intA>${intA}</intA>\n      <intB>${intB}</intB>\n    </${intA}>\n  </soap:Body>\n</soap:Envelope>\n`;

    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
    };

    fetch("http://www.dneonline.com/calculator.asmx", {mode: 'no-cors'}, requestOptions)
        .then(response => response.text())
        .then(result => console.log(result))
        .catch(error => console.log('error', error));
        
    operation = "";
}
