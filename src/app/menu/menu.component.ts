import { Component, OnInit } from '@angular/core';
import {ScriptServiceService} from './../Services/script-service.service'

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor(private _CargarScript:ScriptServiceService) { 
    _CargarScript.Carga(["script"]);
  }

  ngOnInit(): void {
  }

}
