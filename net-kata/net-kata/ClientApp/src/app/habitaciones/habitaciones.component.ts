import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HabitacionService } from '../services/habitacion.service';

declare var $: any;
@Component({
  selector: 'app-habitaciones',
  templateUrl: './habitaciones.component.html',
  styleUrls: ['./habitaciones.component.css']
})
export class HabitacionesComponent implements OnInit {
  @Input() ActiveSelect: boolean = false;
  @Output() HabitacionSeleccionado = new EventEmitter();

  HabitacionForm: FormGroup = new FormGroup({});
  Habitaciones: any[] = [];

  constructor(
    private _habitacionService: HabitacionService
  ) {
    this.InitialForm();
  }

  async ngOnInit() {
    const result = await this._habitacionService.GetAll();
    this.Habitaciones = result;

  }

  InitialForm() {
    this.HabitacionForm = new FormGroup({
      HabitacionId: new FormControl('0', [Validators.required, Validators.minLength(10)]),
      Descripcion: new FormControl('', [Validators.required, Validators.minLength(2)]),
      Piso: new FormControl('0', [Validators.required]),
      Numero: new FormControl('0', [Validators.required]),
      Disponible: new FormControl('', [Validators.required]),
    });
  }

  async Guardar(){
    console.log(this.HabitacionForm.value);
    const result = await this._habitacionService.Add(this.HabitacionForm.value);
    debugger;
    if(result.save){
      this.HabitacionForm.reset();
      
      this.Habitaciones = [];
      const result = await this._habitacionService.GetAll();
      this.Habitaciones = result;
    }
  }

  OpenPopup(){
    $('#crearhabitacionespopup').show();
  }

  Close(): void{
    $('#crearhabitacionespopup').hide();
  }

  SelecionarHabitacion(item: any){
    this.HabitacionSeleccionado.emit({Habitacion: item});
  }

}
