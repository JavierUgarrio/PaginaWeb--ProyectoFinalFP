import { Component } from '@angular/core';
import { UsuarioService } from '../services/usuario.service';

@Component({
  selector: 'app-Login-component',
  templateUrl: './Login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent
{
  constructor(private api: UsuarioService)
  {
    api.dameUsuario().subscribe(resp => { console.log(resp) });
  }
}
