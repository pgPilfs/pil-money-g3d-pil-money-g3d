import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { ContactoService } from '../Services/contacto.service';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-transferencia',
  templateUrl: './transferencia.component.html',
  styleUrls: ['./transferencia.component.css']
})
export class TransferenciaComponent implements OnInit {
  public contacto:any;
   inum = {};
  public item:any;
  public contactoerr:boolean =false;
  contactoadd!: FormGroup;
  constructor(private router:Router, private datoContactos: ContactoService,private fb: FormBuilder,private toastr: ToastrService) {
    var headers_object = new HttpHeaders().set("Authorization", "Bearer " + localStorage.getItem("jwt"));
   
    
   }

  ngOnInit(): void {
    const id: string = localStorage.getItem('idusuario')||'';
    if(id==''){
      this.router.navigateByUrl('404');
    }

    this.datoContactos.ObtenerContactos(parseInt(id)).subscribe(datoContactos => {
      this.item = datoContactos;
      console.log(datoContactos)
    });
    this.contactoadd = this.fb.group({
      alias: new FormControl(''),
    });
  }

  agregarContacto(){
    const id: string = localStorage.getItem('idusuario')||'';
    var inum = {
      idUsuario:parseInt(id),
      idUsuarioAgendado:0,
    };
    var alias = this.contactoadd.controls['alias'].value;
    this.datoContactos.AgregarContacto(inum,alias).subscribe(data=>{
      console.log(data);
      this.toastr.success('Contacto agregado');
    },err=>{
      console.log(err);
      this.contactoerr =true;
    });

  }
  transferencia(idContaco:number){
    console.log(idContaco);
    this.router.navigateByUrl('/paginaprincipal/transferenciacontacto')
    localStorage.setItem("idcontacto", idContaco.toString());
  }
}
