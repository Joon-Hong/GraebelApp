import { Component } from '@angular/core';
import { JobApplication } from './JobApplication';

@Component({
  selector: 'JobApplicationForm',
  templateUrl: './JobApplication.component.html',
  styleUrls: ['./JobApplication.component.css'],
})
export class JobApplicationComponent {
  countries = ['U.S.', 'Canada'];
  states = ['ON', 'QE', 'AB'];

  application = new JobApplication('Joon', ' Hong', 'i am super duper qualified', 'I can do it!', this.states[0], this.countries[1]);

  submitted = false;

  onSubmit() {
    this.submitted = true;
  }
}
