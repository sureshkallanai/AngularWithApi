import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserLoginService } from '../../service/user-login.service';
import { ContactType } from '../../models/ContactType';
import { DisplayService } from '../../display.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrl: './users.component.css'
})
export class UsersComponent  implements OnInit{
  contactTypeList: ContactType[] = [];
  constructor(private userLoginService:UserLoginService,
    public activatedRoute:ActivatedRoute,
    private httpclient:HttpClient,
    private router: Router,
    private displayService: DisplayService){ }
  ngOnInit(): void {
    this.displayService.setNavigationVisibility(false); 
    this.userLoginService.getContactType().subscribe(data=>{this.contactTypeList=data})
  }
  ngOnDestroy(): void {
    this.displayService.setNavigationVisibility(true);
  }
  onLogout(){
    localStorage.setItem("token","");
    this.router.navigateByUrl("/base/login");
  }
}
