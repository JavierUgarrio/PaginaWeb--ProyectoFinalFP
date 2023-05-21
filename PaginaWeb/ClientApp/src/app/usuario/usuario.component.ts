import { Component,Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Usuario } from '../modelos/usuario';
import { UsuarioService } from '../services/usuario.service';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-usuario-component',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})

export class UsuarioComponent {

  altaForm!: FormGroup;
  enviado = false;
  constructor(private api: UsuarioService, private formBuilder: FormBuilder)
  {

  }
  ngOnInit(): void
  {
    this.altaForm = this.formBuilder.group({
      nombre: ['', Validators.required],
      apellidos: ['', Validators.required],
      telefono: ['', Validators.required],
      email: ['', Validators.required, Validators.email],
      pass: ['', Validators.required],
    })
  }

  //Nos devuelve los controles del formulario
  get f(): { [key: string]: AbstractControl } {
    return this.altaForm.controls;
  }

  public Alta()
  {

    this.enviado = true;
    if (this.altaForm.invalid) {
      console.log("invalido")
      return;
    }
    console.log("valido");
    let usuario: Usuario = {
      nombre: this.altaForm.controls['nombre'].value,
      apellidos: this.altaForm.controls['apellidos'].value,
      telefono: this.altaForm.controls['telefono'].value,
      email: this.altaForm.controls['email'].value,
      pass: this.altaForm.controls['pass'].value
    }


    this.api.agregarUsuario(usuario).subscribe(res => {
      if (res.Error != null && res.Error != '') {
        console.log(res.Error);
      } else {
        console.log("Exito");
      }
    });

    //const usuario: Usuario =
    //{
    //  nombre: 'Fonsi ',
    //  apellidos: 'Gon',
    //  telefono: 12345,
    //  email: 'fonsi@gmail.com',
    //  pass: '12345'
    //};
    //this.api.agregarUsuario(usuario).subscribe();
  }
}
