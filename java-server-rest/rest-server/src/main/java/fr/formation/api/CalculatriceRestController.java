package fr.formation.api;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import fr.formation.CalculatriceResult;

@RestController
@RequestMapping("/api/calculatrice")
public class CalculatriceRestController {
	@GetMapping("/additionner")
	public CalculatriceResult additionner(@RequestParam int a, @RequestParam int b) {
		return new CalculatriceResult(a + b);
	}

	@GetMapping("/soustraire")
	public CalculatriceResult soustraire(@RequestParam int a, @RequestParam int b) {
		return new CalculatriceResult(a - b);
	}
}