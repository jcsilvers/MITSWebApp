import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { AllSpeakers } from '../../../graphql/generated/graphql'
import { AdminDataService } from '../../services/admin-data.service';

@Component({
  selector: 'speaker-edit',
  templateUrl: './speaker-edit.component.html',
  styleUrls: ['./speaker-edit.component.scss']
})
export class SpeakerEditComponent implements OnInit {

  constructor(private adminData: AdminDataService) { }

  @Input() speaker: AllSpeakers.Speakers;
  @Output() close = new EventEmitter<boolean>();
  editSpeakerForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    title: new FormControl(''),
    bio: new FormControl(''),
  });

  ngOnInit() {
  }

  stopEditing() {
    this.adminData.removeActiveFromSpeakerList(true);
    this.close.emit(true);
  }
  

}
