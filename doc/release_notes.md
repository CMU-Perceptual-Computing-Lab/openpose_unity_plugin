OpenPose Unity Plugin - Release Notes
============================================

## Current version - v1.0.0 for OpenPose 1.5.0 (Jan 12, 2019)
1. Main functionality:
  1. Import and control OpenPose as dll plugin
  2. OpenPose debugging log in Unity
  3. OpenPose API Wrapper for Unity users, including function:
      1. Start and stop
      2. All OpenPose configuration (pose, face, hand, input, output, extra, gui)
      3. Some enable/disable flag settings (debug, output, image, multi-thread)
  4. Receiving OpenPose output 
      1. Pose (keypoints, ids, scores, heatmaps) 
      2. Hand (keypoints, rectangles, heatmaps)
      3. Face (keypoints, rectangles, heatmaps)
      4. Frame info (id, name, number, subId, subIdMax)
  5. Simple 2D demo scene with example user scripts
