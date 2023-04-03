import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms'
import { ToastrService } from 'ngx-toastr';
import { ReservacionService } from '../services/reservacion.service';

declare var $: any;
@Component({
  selector: 'app-reservacion',
  templateUrl: './reservacion.component.html',
  styleUrls: ['./reservacion.component.css']
})
export class ReservacionComponent implements OnInit {

  ReservacionForm: FormGroup = new FormGroup({});
  Reservaciones: any[] = [];
  Huesped: any = null;
  Habitacion: any = null;
  ErrorMessage: string = '';
  @ViewChild('FechaEntrada', {static: false}) FechaEntradaRefElement!: ElementRef;
  @ViewChild('FechaSalida', {static: false}) FechaSalidaRefElement!: ElementRef;

  constructor(
    private _ReservacionService: ReservacionService,
    private toastr: ToastrService
  ) {
    this.InitialForm();
  }

  async ngOnInit() {
    const result = await this._ReservacionService.GetAll();
    this.Reservaciones = result;

    this.FechaEntradaRefElement.nativeElement.onclick = () =>{
      this.ReservacionForm.patchValue({CheckIn: true});
    }
    this.FechaSalidaRefElement.nativeElement.onclick = () =>{
      this.ReservacionForm.patchValue({CheckOut: true});
    }
  }

  InitialForm() {
    this.ReservacionForm = new FormGroup({
      HuespedId: new FormControl('0', [Validators.required]),
      HabitacionId: new FormControl('0', [Validators.required]),
      FechaEntrada: new FormControl(''),
      FechaSalida: new FormControl(''),
      CheckIn: new FormControl('false'),
      CheckOut: new FormControl('false'),
    });

    this.ReservacionForm.valueChanges.subscribe(() => {
      this.ErrorMessage = '';
    });
  }

  async Guardar(){
    console.log(this.ReservacionForm.value);
    const result = await this._ReservacionService.Add(this.ReservacionForm.value);
    debugger;
    if(result.save){
      this.ReservacionForm.reset();
      
      this.Close();
      this.Reservaciones = [];
      const result = await this._ReservacionService.GetAll();
      this.Reservaciones = result;
    } else {
      this.ErrorMessage = result.error;
      this.toastr.error('Rservación ya esta Asignada', result.error);
    }
  }

  GetHuesped(item: any){
    console.log(item);
    this.CloseSelectHuespedPopup();
    this.Huesped = item.Huesped;
    this.ReservacionForm.patchValue({HuespedId: item.Huesped.huespedId});
  }

  GetHabitacion(item: any){
    console.log(item);
    this.CloseSelectHabitacionPopup();
    this.Habitacion = item.Habitacion;
    this.ReservacionForm.patchValue({HabitacionId: item.Habitacion.habitacionId});
  }

  SelecionarHuespedPopup(){
    $('#selecionarhuespedpopup').show();
  }

  SelecionarHabitacionPopup(){
    $('#selecionarhabitacionpopup').show();
  }

  CloseSelectHuespedPopup(){
    $('#selecionarhuespedpopup').hide();
  }

  CloseSelectHabitacionPopup(){
    $('#selecionarhabitacionpopup').hide();
  }

  OpenPopup(){
    $('#crearreservacionpopup').show();
  }

  Close(): void{
    $('#crearreservacionpopup').hide();
    this.ReservacionForm.reset();
    this.Huesped = null;
    this.Habitacion = null;
  }

}
