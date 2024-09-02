import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WeatherByPincodeComponent } from './weather-by-pincode.component';

describe('WeatherByPincodeComponent', () => {
  let component: WeatherByPincodeComponent;
  let fixture: ComponentFixture<WeatherByPincodeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [WeatherByPincodeComponent]
    });
    fixture = TestBed.createComponent(WeatherByPincodeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
