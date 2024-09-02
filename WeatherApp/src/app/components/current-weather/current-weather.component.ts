import { Component, Input, OnInit } from '@angular/core';
import { WeatherService } from 'src/app/services/weather.service';

@Component({
  selector: 'app-current-weather',
  templateUrl: './current-weather.component.html',
  styleUrls: ['./current-weather.component.css']
})
export class CurrentWeatherComponent {

  @Input() weatherData: any;

  constructor(private weatherService: WeatherService) { }

  ngOnInit(): void {
    //this.getWeather('London'); // default city or use a variable
  }

  getWeather(city: string): void {
    this.weatherService.getCurrentWeather(city).subscribe(data => {
      this.weatherData = data;
    });
  }
}
