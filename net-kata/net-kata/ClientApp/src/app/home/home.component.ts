import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  HuespedForm: FormGroup = new FormGroup({});
  Huespedes: any[] = [];

  public URL: string = '';
  /**
   *
   */
  constructor() {
  }

  async ngOnInit() {
  }

}
