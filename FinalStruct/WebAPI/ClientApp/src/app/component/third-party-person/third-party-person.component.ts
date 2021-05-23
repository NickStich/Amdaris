import { Component, OnInit } from '@angular/core';
import { ThirdPartyPerson } from 'src/app/model/third-party-person';
import { ThirdPersonType } from 'src/app/model/ThirdPersonType';
import { ThirdPartyPersonService } from 'src/app/service/third-party-person.service';

@Component({
  selector: 'app-third-party-person',
  templateUrl: './third-party-person.component.html',
  styleUrls: ['./third-party-person.component.css']
})
export class ThirdPartyPersonComponent implements OnInit {

  tpps: ThirdPartyPerson[] = [];

  constructor(private tppService: ThirdPartyPersonService) { }

  ngOnInit(): void {
    this.tppService.findAll().subscribe(data => {
      this.tpps = data;
    });
  }


}
