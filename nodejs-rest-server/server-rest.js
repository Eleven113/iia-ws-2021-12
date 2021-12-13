const express = require('express');
const jwt = require('jsonwebtoken');
const bodyParser = require('body-parser');
const app = express();
const accessTokenSecret = 'VoiciLaCleSecreteTresSecrete';
const port = 3000;
const authUrl = '/api/auth';

const users = [
	{
		username: 'jeremy',
		password: 'toto'
	}
];

app.use(bodyParser.json());

const authenticateJWT = (req, res, next) => {
	const authHeader = req.headers.authorization;

	if (req.url == authUrl) {
		next();
		return;
	}

	if (authHeader) {
		const token = authHeader.split(' ')[1];

		jwt.verify(token, accessTokenSecret, (err, user) => {
			if (err) {
				return res.sendStatus(403);
			}

			req.user = user;
			next();
		});
	}
	
	else {
		res.sendStatus(401);
	}
};

app.use(authenticateJWT);

app.post(authUrl, (req, res) => {
	const { username, password } = req.body;

	// Filter user from the users array by username and password
	const user = users.find(u => { return u.username === username && u.password === password });

	if (user) {
		// Generate an access token
		const accessToken = jwt.sign({ username: user.username }, accessTokenSecret);

		res.json({
			accessToken
		});
	} else {
		res.send('Username or password incorrect');
	}
});


app.get('/api/calculatrice/additionner', (req, res) => {
	res.send({
		value: parseInt(req.query.a) + parseInt(req.query.b)
	});
});


app.get('/api/calculatrice/additionner', (req, res) => {
	res.send({
		value: parseInt(req.query.a) + parseInt(req.query.b)
	});
});


app.get('/api/calculatrice/soustraire', authenticateJWT, (req, res) => {
	res.send({
		value: parseInt(req.query.a) - parseInt(req.query.b)
	});
});

app.listen(port, () => {
  console.log(`Example app listening at http://localhost:${port}`)
});