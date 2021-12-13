var soap = require('soap');
var url = 'http://localhost:5094/Calculatrice.asmx?wsdl';
var args = { a: 5, b: 6 };

(async () => {
	let operation = "Additionner";
	let client = await soap.createClientAsync(url);
	// let rawResult = await client.AdditionnerAsync(args);
	let rawResult = await client[`${ operation }Async`](args);
	let result = rawResult[0][`${ operation }Result`];

	console.log(`Résult = ${ result.Value }`);
})();