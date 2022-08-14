import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admindashboard',
  templateUrl: './admindashboard.component.html',
  styleUrls: ['./admindashboard.component.css']
})
export class AdmindashboardComponent implements OnInit {

  constructor(private route :Router) { }

  ngOnInit(): void {
  }
onLogout(){
  localStorage.removeItem('token');
  this.route.navigateByUrl('/login');

}
Sales(){
  
}
}
