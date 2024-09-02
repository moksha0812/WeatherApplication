import { Component } from '@angular/core';
import { WeatherService } from './services/weather.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  city: string = '';
  pincode: string = '';
  currentWeather: any;
  weatherForecast: any;
  airQuality: any;
  showWeather: boolean = false;
  errorMessage: string = ''; // To store error messages
  validationError: string = ''; // To store validation errors

  constructor(private weatherService: WeatherService) {}

  getWeather(): void {
    if (!this.city) {
      this.validationError = 'City name is required.';
      return;
    }
    this.validationError = '';
    this.weatherService.getCurrentWeather(this.city).subscribe(
      data => {
        this.currentWeather = data;
        this.errorMessage = ''; // Clear any previous errors
      },
      error => {
        this.errorMessage = 'Error fetching current weather. Please try again later.';
        console.error('Error fetching current weather:', error);
      }
    );
  }

  getForecast(): void {
    if (!this.city) {
      this.validationError = 'City name is required.';
      return;
    }
    this.validationError = '';
    this.weatherService.getWeatherForecast(this.city).subscribe(
      data => {
        this.weatherForecast = data;
        this.errorMessage = ''; // Clear any previous errors
      },
      error => {
        this.errorMessage = 'Error fetching weather forecast. Please try again later.';
        console.error('Error fetching weather forecast:', error);
      }
    );
  }

  getAirQuality(): void {
    if (!this.city) {
      this.validationError = 'City name is required.';
      return;
    }
    this.validationError = '';
    this.weatherService.getAirQuality(this.city).subscribe(
      data => {
        this.airQuality = data;
        this.errorMessage = ''; // Clear any previous errors
      },
      error => {
        this.errorMessage = 'Error fetching air quality. Please try again later.';
        console.error('Error fetching air quality:', error);
      }
    );
  }

  getWeatherByPincode(): void {
    if (!this.pincode || this.pincode.length !== 6) {
      this.validationError = 'Valid pincode is required (6 digits).';
      return;
    }
    this.validationError = '';
    this.showWeather = true;
  }
}
