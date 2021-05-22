import { Component, OnInit } from '@angular/core';
import { ThirdPartyPerson } from 'src/app/model/third-party-person';
import { ThirdPartyPersonService } from 'src/app/service/third-party-person.service';

@Component({
  selector: 'app-third-party-person',
  templateUrl: './third-party-person.component.html',
  styleUrls: ['./third-party-person.component.css']
})
export class ThirdPartyPersonComponent implements OnInit {

  lengthDisplay: number;
  tpps: ThirdPartyPerson[] = [];

  constructor(private tppService: ThirdPartyPersonService) { }

  ngOnInit(): void {
    this.tppService.findAll().subscribe(data => {
      this.tpps = data;
      this.lengthDisplay = this.tpps.length;
    });
  }

}
