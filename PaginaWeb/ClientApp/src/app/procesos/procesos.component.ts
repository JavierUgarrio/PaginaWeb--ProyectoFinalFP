
import { Component, Input, OnInit } from '@angular/core';
import { ProcesosService } from '../services/procesos.service';
//import { Proceso } from '../modelos/Proceso';
import { objetoProceso } from '../modelos/objetoProceso';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { Login } from '../modelos/login';

@Component({
  selector: 'app-procesos-component',
  templateUrl: './procesos.component.html',
  styleUrls: ['./procesos.component.css']
})

export class ProcesosComponent implements OnInit
{
  public listaProcesos!: any[];
  altaForm!: FormGroup;
  altaFormLogin !: FormGroup;
  enviado = false;
  constructor(private api: ProcesosService, private formBuilder: FormBuilder) {
    //api.dameProcesos().subscribe(resp => { console.log(resp) })
  }
  ngOnInit(): void {
    
    this.dameProcesos();
    
    this.altaForm = this.formBuilder.group({
      email: ['', Validators.required],
      pass: ['', Validators.required],
      nombre: ['', Validators.required],
      descripcion: ['', Validators.required],
      cliente: ['', Validators.required],
      
    })
  }

  
  dameProcesos()
  {
    this.api.dameProcesos().subscribe(res => { 
      this.listaProcesos = res.objetoGenerico;
      //console.log(this.listaProcesos);
    });
  }

  get f(): { [key: string]: AbstractControl } {
    return this.altaForm.controls;
  }

  public Alta() {

    this.enviado = true;
    if (this.altaForm.invalid) {
      console.log("invalido")
      return;
    }
    console.log("valido");
    let proceso: objetoProceso = {
      email: this.altaForm.controls['email'].value,
      pass: this.altaForm.controls['pass'].value,
      nombre: this.altaForm.controls['nombre'].value,
      descripcion: this.altaForm.controls['descripcion'].value,
      cliente: this.altaForm.controls['cliente'].value,
    }


    this.api.agregarProceso(proceso).subscribe(res => {
      if (res.Error != null && res.Error != '') {
        console.log(res.Error);
      } else {
        console.log("Exito");
      }
    });

  }


  

}
