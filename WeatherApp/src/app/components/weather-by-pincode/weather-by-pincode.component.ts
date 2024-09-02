import { Component, Input, OnInit } from '@angular/core';
import { WeatherService } from 'src/app/services/weather.service';

@Component({
  selector: 'app-weather-by-pincode',
  templateUrl: './weather-by-pincode.component.html',
  styleUrls: ['./weather-by-pincode.component.css']
})
export class WeatherByPincodeComponent implements OnInit {
  @Input() pincode!: string;
  weatherData: any;
  errorMessage!:string;
  constructor(private weatherService: WeatherService) {}

  ngOnInit(): void {
    if (this.pincode) {
      this.getWeatherByPincode(this.pincode);
    }
  }

  getWeatherByPincode(pincode: string): void {
    this.weatherService.getCurrentWeatherByPincode(pincode).subscribe(data => {
      this.weatherData = data;
    }, error => {
      this.errorMessage='Error fetching weather data';
      console.error('Error fetching weather data:', error);
    });
  }
}

