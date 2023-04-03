import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CustomValidator } from '../CustomFormValidators/custom-validator';
import { HuespedService } from '../services/huesped.service';

declare var $: any;
@Component({
  selector: 'app-huesped',
  templateUrl: './huesped.component.html',
  styleUrls: ['./huesped.component.css']
})
export class HuespedComponent implements OnInit {
  @Input() ActiveSelect: boolean = false;
  @Output() HuespedSeleccionado = new EventEmitter();
  HuespedForm: FormGroup = new FormGroup({});
  Huespedes: any[] = [];

  constructor(
    private _huespedService: HuespedService
  ) {
    this.InitialForm();
  }

  async ngOnInit() {
    const result = await this._huespedService.GetAll();
    this.Huespedes = result;
  }

  InitialForm() {
    this.HuespedForm = new FormGroup({
      Identificacion: new FormControl('', [Validators.required, Validators.minLength(10)]),
      Nombre: new FormControl('', [Validators.required, Validators.minLength(2)]),
      Apellido: new FormControl('', [Validators.required, Validators.minLength(2)]),
      Email: new FormControl('', [Validators.required, Validators.minLength(2), Validators.email, CustomValidator.emailValidator]),
      Telefono: new FormControl('', [Validators.required, Validators.minLength(2)]),
    });
  }

  async Guardar(){
    const result = await this._huespedService.Add(this.HuespedForm.value);
    debugger;
    if(result.save){
      this.HuespedForm.reset();
      
      this.Huespedes = [];
      const result = await this._huespedService.GetAll();
      this.Huespedes = result;

      this.Close();
    }
  }

  OpenPopup(){
    $('#crearhuespedpopup').show();
  }

  Close(): void{
    $('#crearhuespedpopup').hide();
  }

  SelecionarHuesped(item: any){
    this.HuespedSeleccionado.emit({Huesped: item});
  }

}
