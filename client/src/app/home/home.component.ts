
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  users: any;

  constructor(private toastr: ToastrService){}

  ngOnInit(): void{
    
  }

  registerToggle(){
    this.registerMode = !this.registerMode
  }

  moreInfoButton(){
    this.toastr.show('Still in development ^_^');
  }

  cancelRegisterMode(event: boolean){
    this.registerMode = event;
  }
}
