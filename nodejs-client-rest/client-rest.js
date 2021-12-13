const axios = require('axios');

//Pour désactiver la vérification des erreurs certificats : certificats auto-signés (self-signed)
const https = require('https');
const httpsAgent = new https.Agent({ rejectUnauthorized: false });

let url = 'http://localhost:5152/api/calculatrice/additionner';
let args = { a: 5, b: 6 };

(async () => {
	let rawResult = await axios.get(url, {
			params: args,
			httpsAgent //Certificat self-signed
		});
	
	let result = rawResult.data;
	
	console.log(result.value);
})();